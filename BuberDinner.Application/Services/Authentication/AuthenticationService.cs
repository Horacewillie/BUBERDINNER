using System;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                email,
                "token",
                "firstName",
                "lastName");
        }

        public AuthenticationResult Register(string email, string password, string firstName, string lastName)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                email,
                "token",
                firstName,
                lastName);
        }
    }
}