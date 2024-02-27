namespace WeatherApp.Domain.Entities;

public abstract class EntityBase
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}