namespace RestApi.Models;

public class SmallRequest
{
    public string Name { get; set; } = string.Empty;
}

public class MediumRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}

public class LargeRequest
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }
    public List<string> Skills { get; set; } = new();
    public Dictionary<string, string> Metadata { get; set; } = new();
    public string Company { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
} 