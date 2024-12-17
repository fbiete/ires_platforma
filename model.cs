public class Client
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
}

public class Car
{
    public int Id { get; set; }
    public string Model { get; set; }
    public double HourlyRate { get; set; }
    public double KmRate { get; set; }
}

public class Rental
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int CarId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public double? KmDriven { get; set; }
    public double? TotalAmount { get; set; }
}
