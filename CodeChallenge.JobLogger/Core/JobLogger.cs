using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CodeChallenge.Infrastructure;
using CodeChallenge.JobLogger.Sinks;

namespace CodeChallenge.JobLogger.Core
{
    public class JobLogger : ILoggeable, ISanitizable
    {
        private readonly ICollection<ILoggeable> _sinks = new Collection<ILoggeable>();
        public JobLogger(JobLoggerConfiguration configuration)
        {
           if (configuration.LogToFile) 
               _sinks.Add(new LogFileSink());
           if (configuration.LogToConsole)
               _sinks.Add(new ColoredConsoleSink());
           if (configuration.LogToDb)
               _sinks.Add(new DbStorageSink());
        }

        void ILoggeable.Log(LogLevel level, string message)
        {
            if (IsNotEmpty(message, out var parsedMessage))
                return;

            switch (level)
            {
                case LogLevel.Debug:
                    LogInAllSinks(log => log.LogDebug(parsedMessage));
                    break;
                case LogLevel.Error:
                    LogInAllSinks(log => log.LogError(parsedMessage));
                    break;
                case LogLevel.Warning:
                    LogInAllSinks(log => log.LogWarning(parsedMessage));
                    break;
                case LogLevel.Message:
                    LogInAllSinks(log => log.LogMessage(parsedMessage));
                    break;
            }
        }

        void ILoggeable.LogWarning(string message)
            => ((ILoggeable) this).Log(LogLevel.Warning, message);

        void ILoggeable.LogError(string message)
            => ((ILoggeable) this).Log(LogLevel.Error, message);

        void ILoggeable.LogMessage(string message)
            => ((ILoggeable)this).Log(LogLevel.Message, message);

        void ILoggeable.LogDebug(string message)
            => ((ILoggeable)this).Log(LogLevel.Debug, message);

        private void LogInAllSinks(Action<ILoggeable> action)
        {
            foreach (var sink in _sinks)
                action(sink);
        }

        public bool IsNotEmpty(string message, out string parsedMessage)
        {
            parsedMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(message))
                return false;

            parsedMessage = message.Trim();
            return true;
        }
    }
}
