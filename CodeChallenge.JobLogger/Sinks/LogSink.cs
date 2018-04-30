using CodeChallenge.Infrastructure;

namespace CodeChallenge.JobLogger.Sinks
{
    public abstract class LogSink : ILoggeable
    {
        void ILoggeable.Log(LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    LogDebug(message);
                    break;
                case LogLevel.Error:
                    LogError(message);
                    break;
                case LogLevel.Warning:
                    LogWarning(message);
                    break;
                case LogLevel.Message:
                    LogMessage(message);
                    break;
            }
        }

        public abstract void LogWarning(string message);

        public abstract void LogError(string message);

        public abstract void LogMessage(string message);

        public abstract void LogDebug(string message);
    }
}
