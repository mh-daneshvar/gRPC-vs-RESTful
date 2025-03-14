using System.Diagnostics;
using System.Text.Json;
using Grpc.Net.Client;
using GrpcApi;
using PerformanceTests.Models;
using Spectre.Console;

namespace PerformanceTests.Services;

public class PerformanceTestService
{
    private readonly HttpClient _httpClient;
    private readonly GrpcApi.TestService.TestServiceClient _grpcClient;
    private const int TotalRequests = 200_000;
    private const int ConcurrentRequests = 100;
    private const string RestApiUrl = "http://localhost:5001";
    private const string GrpcApiUrl = "http://localhost:5002";

    public PerformanceTestService()
    {
        _httpClient = new HttpClient();
        var channel = GrpcChannel.ForAddress(GrpcApiUrl);
        _grpcClient = new TestService.TestServiceClient(channel);

        AnsiConsole.MarkupLine($"\n[bold]Configuration:[/]");
        AnsiConsole.MarkupLine($"REST API URL: [green]{RestApiUrl}[/]");
        AnsiConsole.MarkupLine($"gRPC API URL: [blue]{GrpcApiUrl}[/]");
        AnsiConsole.MarkupLine($"Total Requests: [yellow]{TotalRequests:N0}[/]");
        AnsiConsole.MarkupLine($"Concurrent Requests: [yellow]{ConcurrentRequests:N0}[/]\n");
    }

    public async Task RunRestTests()
    {
        AnsiConsole.MarkupLine("\n[bold green]🟢 RESTful API Tests[/]");

        // Test API availability
        try
        {
            var response = await _httpClient.GetAsync($"{RestApiUrl}/WeatherForecast");
            if (!response.IsSuccessStatusCode)
            {
                AnsiConsole.MarkupLine("[bold red]⚠️ REST API is not responding. Please ensure it's running.[/]");
                return;
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[bold red]⚠️ Error connecting to REST API: {ex.Message}[/]");
            return;
        }

        await RunTest("Small Payload", "/test/small", TestData.SmallPayload);
        await RunTest("Medium Payload", "/test/medium", TestData.MediumPayload);
        await RunTest("Large Payload", "/test/large", TestData.LargePayload);
    }

    public async Task RunGrpcTests()
    {
        AnsiConsole.MarkupLine("\n[bold blue]🔵 gRPC API Tests[/]");

        // Test API availability
        try
        {
            await _grpcClient.GetSmallAsync(new SmallRequest { Name = "test" });
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[bold red]⚠️ Error connecting to gRPC API: {ex.Message}[/]");
            return;
        }

        await RunGrpcTest("Small Payload", CreateSmallRequest());
        await RunGrpcTest("Medium Payload", CreateMediumRequest());
        await RunGrpcTest("Large Payload", CreateLargeRequest());
    }

    private async Task RunTest(string name, string endpoint, object payload)
    {
        AnsiConsole.MarkupLine($"\n[bold yellow]🟡 {name}[/]");
        
        var stopwatch = Stopwatch.StartNew();
        var tasks = new List<Task>();
        var errors = 0;
        var completed = 0;
        var latencies = new List<double>();

        await AnsiConsole.Progress()
            .StartAsync(async ctx =>
            {
                var progressTask = ctx.AddTask($"[yellow]Processing[/]");
                progressTask.MaxValue = TotalRequests;

                for (int i = 0; i < TotalRequests; i += ConcurrentRequests)
                {
                    var batchSize = Math.Min(ConcurrentRequests, TotalRequests - i);
                    var batchTasks = new List<Task>();

                    for (int j = 0; j < batchSize; j++)
                    {
                        batchTasks.Add(Task.Run(async () =>
                        {
                            var requestStopwatch = Stopwatch.StartNew();
                            try
                            {
                                var response = await _httpClient.PostAsJsonAsync($"{RestApiUrl}{endpoint}", payload);
                                if (!response.IsSuccessStatusCode)
                                    Interlocked.Increment(ref errors);
                            }
                            catch
                            {
                                Interlocked.Increment(ref errors);
                            }
                            finally
                            {
                                requestStopwatch.Stop();
                                lock (latencies)
                                {
                                    latencies.Add(requestStopwatch.Elapsed.TotalMilliseconds);
                                }
                                Interlocked.Increment(ref completed);
                                progressTask.Increment(1);
                            }
                        }));
                    }

                    await Task.WhenAll(batchTasks);
                }
            });

        stopwatch.Stop();
        var rps = TotalRequests / stopwatch.Elapsed.TotalSeconds;

        var table = new Table();
        table.AddColumn("Metric");
        table.AddColumn("Value");

        table.AddRow("Total Requests", TotalRequests.ToString("N0"));
        table.AddRow("Completed", completed.ToString("N0"));
        table.AddRow("Errors", errors.ToString("N0"));
        table.AddRow("Duration", $"{stopwatch.Elapsed.TotalSeconds:F2}s");
        table.AddRow("Requests/sec", $"{rps:F2}");
        table.AddRow("Avg Latency", $"{latencies.Average():F2}ms");
        table.AddRow("Min Latency", $"{latencies.Min():F2}ms");
        table.AddRow("Max Latency", $"{latencies.Max():F2}ms");
        table.AddRow("P95 Latency", $"{GetPercentile(latencies, 95):F2}ms");

        AnsiConsole.Write(table);
    }

    private async Task RunGrpcTest(string name, object request)
    {
        AnsiConsole.MarkupLine($"\n[bold yellow]🟡 {name}[/]");
        
        var stopwatch = Stopwatch.StartNew();
        var tasks = new List<Task>();
        var errors = 0;
        var completed = 0;
        var latencies = new List<double>();

        await AnsiConsole.Progress()
            .StartAsync(async ctx =>
            {
                var progressTask = ctx.AddTask($"[yellow]Processing[/]");
                progressTask.MaxValue = TotalRequests;

                for (int i = 0; i < TotalRequests; i += ConcurrentRequests)
                {
                    var batchSize = Math.Min(ConcurrentRequests, TotalRequests - i);
                    var batchTasks = new List<Task>();

                    for (int j = 0; j < batchSize; j++)
                    {
                        batchTasks.Add(Task.Run(async () =>
                        {
                            var requestStopwatch = Stopwatch.StartNew();
                            try
                            {
                                switch (request)
                                {
                                    case SmallRequest small:
                                        await _grpcClient.GetSmallAsync(small);
                                        break;
                                    case MediumRequest medium:
                                        await _grpcClient.GetMediumAsync(medium);
                                        break;
                                    case LargeRequest large:
                                        await _grpcClient.GetLargeAsync(large);
                                        break;
                                }
                            }
                            catch
                            {
                                Interlocked.Increment(ref errors);
                            }
                            finally
                            {
                                requestStopwatch.Stop();
                                lock (latencies)
                                {
                                    latencies.Add(requestStopwatch.Elapsed.TotalMilliseconds);
                                }
                                Interlocked.Increment(ref completed);
                                progressTask.Increment(1);
                            }
                        }));
                    }

                    await Task.WhenAll(batchTasks);
                }
            });

        stopwatch.Stop();
        var rps = TotalRequests / stopwatch.Elapsed.TotalSeconds;

        var table = new Table();
        table.AddColumn("Metric");
        table.AddColumn("Value");

        table.AddRow("Total Requests", TotalRequests.ToString("N0"));
        table.AddRow("Completed", completed.ToString("N0"));
        table.AddRow("Errors", errors.ToString("N0"));
        table.AddRow("Duration", $"{stopwatch.Elapsed.TotalSeconds:F2}s");
        table.AddRow("Requests/sec", $"{rps:F2}");
        table.AddRow("Avg Latency", $"{latencies.Average():F2}ms");
        table.AddRow("Min Latency", $"{latencies.Min():F2}ms");
        table.AddRow("Max Latency", $"{latencies.Max():F2}ms");
        table.AddRow("P95 Latency", $"{GetPercentile(latencies, 95):F2}ms");

        AnsiConsole.Write(table);
    }

    private static double GetPercentile(List<double> values, double percentile)
    {
        var sortedValues = values.OrderBy(x => x).ToList();
        var index = (int)Math.Ceiling(percentile / 100.0 * sortedValues.Count) - 1;
        return sortedValues[index];
    }

    private static SmallRequest CreateSmallRequest() => new() { Name = "John Doe" };
    
    private static MediumRequest CreateMediumRequest() => new()
    {
        Name = "John Doe",
        Email = "john@example.com",
        Phone = "+1234567890"
    };
    
    private static LargeRequest CreateLargeRequest() => new()
    {
        Name = "John Doe",
        Age = 30,
        Email = "john@example.com",
        Address = "123 Main St",
        City = "New York",
        State = "NY",
        Country = "USA",
        Phone = "+1234567890",
        Salary = 75000,
        IsActive = true,
        Skills = { "C#", "ASP.NET", "gRPC" },
        Metadata = { { "key1", "value1" }, { "key2", "value2" } },
        Company = "Tech Corp",
        Department = "Engineering"
    };
} 