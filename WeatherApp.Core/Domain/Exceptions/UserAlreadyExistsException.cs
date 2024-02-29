namespace WeatherApp.Core.Domain.Exceptions
{
    public sealed class UserAlreadyExistsException : BadRequestException
    {
        public UserAlreadyExistsException(string name)
            : base($"User name {name} already exists. Please select a different user name")
        {
        }
    }
}