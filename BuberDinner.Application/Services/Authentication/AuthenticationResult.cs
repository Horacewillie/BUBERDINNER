using System;

namespace BuberDinner.Application.Services.Authentication
{
    public record AuthenticationResult(
        Guid Id,
        string Email,
        string Token,
        string FirstName,
        string LastName
    );
}