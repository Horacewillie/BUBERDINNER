using System;
using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

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
           Guid userId =   Guid.NewGuid();
           var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
           
            return new AuthenticationResult(
               userId,
                email,
                token,
                firstName,
                lastName);
        }
    }
}