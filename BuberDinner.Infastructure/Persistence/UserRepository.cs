using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BuberDinner.Infastructure.Persistence
{
    public class UserRepository : IUserRepository

    {
        private static readonly List<User> _users = new();
        void IUserRepository.AddUser(User user)
        {
            _users.Add(user);
        }

        User? IUserRepository.GetByEmail(string email)
        {
           var user = _users.Find(u => u.Email == email);
           return user;
        }
    }
}