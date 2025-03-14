using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcApi.Services;

public class TestService : GrpcApi.TestService.TestServiceBase
{
    private readonly ILogger<TestService> _logger;

    public TestService(ILogger<TestService> logger)
    {
        _logger = logger;
    }

    public override Task<SmallResponse> GetSmall(SmallRequest request, ServerCallContext context)
    {
        return Task.FromResult(new SmallResponse
        {
            Message = $"Hello, {request.Name}!"
        });
    }

    public override Task<MediumResponse> GetMedium(MediumRequest request, ServerCallContext context)
    {
        return Task.FromResult(new MediumResponse
        {
            Message = $"Hello, {request.Name}!",
            Email = request.Email,
            Phone = request.Phone
        });
    }

    public override Task<LargeResponse> GetLarge(LargeRequest request, ServerCallContext context)
    {
        return Task.FromResult(new LargeResponse
        {
            Name = request.Name,
            Age = request.Age,
            Email = request.Email,
            Address = request.Address,
            City = request.City,
            State = request.State,
            Country = request.Country,
            Phone = request.Phone,
            Salary = request.Salary,
            IsActive = request.IsActive,
            Skills = { request.Skills },
            Metadata = { request.Metadata },
            Company = request.Company,
            Department = request.Department
        });
    }
} 