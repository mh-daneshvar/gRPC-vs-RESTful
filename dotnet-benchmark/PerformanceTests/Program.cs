using PerformanceTests.Services;
using Spectre.Console;

var testService = new PerformanceTestService();

AnsiConsole.Write(new FigletText("gRPC vs REST Benchmark")
    .Centered()
    .Color(Color.Green));

AnsiConsole.MarkupLine("\n[bold]Starting performance tests...[/]\n");

await testService.RunRestTests();
await testService.RunGrpcTests();

AnsiConsole.MarkupLine("\n[bold green]✅ All tests completed![/]"); 