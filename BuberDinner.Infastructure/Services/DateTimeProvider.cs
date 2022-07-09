using System;
using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
        
    }
}