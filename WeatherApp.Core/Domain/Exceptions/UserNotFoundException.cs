namespace WeatherApp.Core.Domain.Exceptions
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(Guid userLogin)
            : base($"The user with the id: {userLogin} was not found.")
        {
        }

        public UserNotFoundException(string name)
            : base($"User name {name} was not found.")
        {
        }
    }
}