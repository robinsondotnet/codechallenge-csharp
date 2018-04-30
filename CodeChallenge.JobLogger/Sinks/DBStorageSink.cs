using System;
using CodeChallenge.Infrastructure;

namespace CodeChallenge.JobLogger.Sinks
{
    public class DbStorageSink : ILoggeable
    {
        void ILoggeable.Log(LogLevel leve, string message)
        {
            throw new NotImplementedException();
        }

        void ILoggeable.LogWarning(string message)
        {
            throw new NotImplementedException();
        }

        void ILoggeable.LogError(string message)
        {
            throw new NotImplementedException();
        }

        void ILoggeable.LogMessage(string message)
        {
            throw new NotImplementedException();
        }

        void ILoggeable.LogDebug(string message)
        {
            throw new NotImplementedException();
        }
    }
}
