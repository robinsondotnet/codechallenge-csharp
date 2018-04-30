using System;
using CodeChallenge.Infrastructure;

namespace CodeChallenge.JobLogger.Sinks
{
    public class LogFileSink : ILoggeable
    {
        void ILoggeable.Log(string message)
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
    }
}
