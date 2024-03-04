namespace WeatherApp.Core.Domain.Exceptions
{
    public sealed class ServiceNotAvailableException : NotFoundException
    {

        public ServiceNotAvailableException(string name)
            : base($"{name} not available at this time.")
        {
        }
    }
}