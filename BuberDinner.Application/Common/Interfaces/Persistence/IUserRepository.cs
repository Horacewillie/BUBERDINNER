using System;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetByEmail(string email);
        void AddUser(User user);
    }
}