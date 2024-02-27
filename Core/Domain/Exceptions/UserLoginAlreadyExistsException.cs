namespace WeatherApp.Domain.Exceptions
{
    public sealed class UserLoginAlreadyExistsException : BadRequestException
    {
        public UserLoginAlreadyExistsException(string name)
            : base($"The login with user name {name} already exists. Please select a different user name")
        {
        }
    }
}
