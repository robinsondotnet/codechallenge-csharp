using System.IO;
using CodeChallenge.Infrastructure;

namespace CodeChallenge.JobLogger.Sinks
{
    public class LogFileSink : LogSink
    {
        private readonly string _storagePath;
        private readonly ITimeProvider _timeProvider;

        public LogFileSink(ITimeProvider timeProvider, string storagePath)
        {
            _timeProvider = timeProvider;

            if (!Directory.Exists(storagePath))
                throw new DirectoryNotFoundException();

            _storagePath = $"{storagePath}/JobLogger{_timeProvider.GetShortDate()}.txt";
        }

        private void WriteToFile(string message)
        {
            if (!File.Exists(_storagePath))
                File.Create(_storagePath);

            using (StreamWriter sw = File.AppendText(_storagePath))
                sw.Write(_timeProvider.AppendTime(message));
        }

        public override void LogWarning(string message)
            => WriteToFile($" [WARNING] {message}");

        public override void LogError(string message)
            => WriteToFile($" [ERROR] {message}");

        public override void LogMessage(string message)
            => WriteToFile($" [MESSAGE] {message}");

        public override void LogDebug(string message)
            => WriteToFile($" [DEBUG] {message}");
    }
}
