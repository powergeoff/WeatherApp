using System;

namespace WeatherApp.Domain.Exceptions
{
    public sealed class UserLoginNotFoundException : NotFoundException
    {
        public UserLoginNotFoundException(Guid userLogin)
            : base($"The owner with the identifier {userLogin} was not found.")
        {
        }

        public UserLoginNotFoundException(string name)
            : base($"The owner with the identifier {name} was not found.")
        {
        }
    }
}
