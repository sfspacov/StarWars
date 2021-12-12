using System;

namespace StarWars.Domain.Interfaces
{
    public interface ILogger
    {
        void LogException(Exception ex);

        void LogException(Exception ex, string message);
    }
}