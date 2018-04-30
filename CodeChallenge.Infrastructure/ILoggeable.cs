namespace CodeChallenge.Infrastructure
{
    public interface ILoggeable
    {
        void Log(LogLevel level, string message);

        void LogWarning(string message);

        void LogError(string message);

        void LogMessage(string message);

        void LogDebug(string message);
    }
}
