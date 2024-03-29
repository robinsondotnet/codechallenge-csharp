﻿using System;
using System.Collections.Generic;
using CodeChallenge.Infrastructure;
using CodeChallenge.JobLogger.Sinks;

namespace CodeChallenge.JobLogger.Core
{
    public class JobLogger : ILoggeable, ISanitizable
    {
        private readonly IList<ILoggeable> _sinks = new List<ILoggeable>();

        private readonly LogLevel _minimumLogLevel;

        public JobLogger(JobLoggerConfiguration configuration)
        {
            var timeProvider = new TimeProvider(TimeZoneInfo.Utc);
           if (configuration.LogToFile) 
               _sinks.Add(new LogFileSink(timeProvider, configuration.StoragePath));
           if (configuration.LogToConsole)
               _sinks.Add(new ColoredConsoleSink(timeProvider));
           if (configuration.LogToDb)
               _sinks.Add(new DbStorageSink(configuration.ConnectionString));

            _minimumLogLevel = configuration.LogLevel;
        }

        void ILoggeable.Log(LogLevel level, string message)
        {
            if (IsNotEmpty(message, out var parsedMessage) && !IsLoggeable(level))
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

        private bool IsLoggeable(LogLevel requested)
            => requested >= _minimumLogLevel;

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
