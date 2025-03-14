namespace PerformanceTests.Models;

public static class TestData
{
    public static object SmallPayload => new { name = "John Doe" };
    
    public static object MediumPayload => new
    {
        name = "John Doe",
        email = "john@example.com",
        phone = "+1234567890"
    };
    
    public static object LargePayload => new
    {
        name = "John Doe",
        age = 30,
        email = "john@example.com",
        address = "123 Main St",
        city = "New York",
        state = "NY",
        country = "USA",
        phone = "+1234567890",
        salary = 75000.00,
        isActive = true,
        skills = new[] { "C#", "ASP.NET", "gRPC" },
        metadata = new Dictionary<string, string>
        {
            { "key1", "value1" },
            { "key2", "value2" }
        },
        company = "Tech Corp",
        department = "Engineering"
    };
} 