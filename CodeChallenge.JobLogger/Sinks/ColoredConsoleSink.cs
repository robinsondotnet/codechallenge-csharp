using System;
using CodeChallenge.Infrastructure;

namespace CodeChallenge.JobLogger.Sinks
{
    public class ColoredConsoleSink : ILoggeable
    {
        void ILoggeable.Log(LogLevel level, string message)
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
