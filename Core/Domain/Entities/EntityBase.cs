namespace WeatherApp.Domain.Entities;

public abstract class EntityBase
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}