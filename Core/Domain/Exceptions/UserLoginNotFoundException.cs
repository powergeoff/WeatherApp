using System;

namespace WeatherApp.Domain.Exceptions
{
    public sealed class UserLoginNotFoundException : NotFoundException
    {
        public UserLoginNotFoundException(Guid userLogin)
            : base($"The login with the identifier {userLogin} was not found.")
        {
        }

        public UserLoginNotFoundException(string name)
            : base($"The login with the user name {name} was not found.")
        {
        }
    }
}
