using System;
using CodeChallenge.Infrastructure;

namespace CodeChallenge.JobLogger.Sinks
{
    public class ColoredConsoleSink : LogSink
    {
        private readonly ITimeProvider _timeProvider;

        public ColoredConsoleSink(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public override void LogWarning(string message)
            => WriteConsole(ConsoleColor.Yellow, message);

        public override void LogError(string message)
            => WriteConsole(ConsoleColor.Red, message);

        public override void LogMessage(string message)
            => WriteConsole(ConsoleColor.White, message);

        public override void LogDebug(string message)
            => WriteConsole(ConsoleColor.Gray, message);

        private void WriteConsole(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(_timeProvider.AppendTime(message));
        }
    }
}
