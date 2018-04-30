namespace CodeChallenge.Infrastructure
{
    public interface ILoggeable
    {
        void Log(string message);

        void LogWarning(string message);

        void LogError(string message);

        void LogMessage(string message);
    }
}
