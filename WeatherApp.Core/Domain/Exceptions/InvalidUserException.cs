namespace WeatherApp.Core.Domain.Exceptions
{
    public sealed class InvalidUserException : BadRequestException
    {
        public InvalidUserException()
            : base($"Invalid credentials!")
        {
        }
    }
}