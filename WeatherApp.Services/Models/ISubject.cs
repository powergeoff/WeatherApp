namespace WeatherApp.Services.Models;

public interface ISubject
{
    void AddObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void Notify();
}