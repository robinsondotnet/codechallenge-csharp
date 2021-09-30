using System;
using System.Configuration;
using CodeChallenge.Infrastructure;

namespace CodeChallenge.JobLogger.Core
{
    public class JobLoggerConfiguration
    {
        public bool LogToDb { get; set; }

        public bool LogToFile { get; set; }

        public bool LogToConsole { get; set; }

        public string StoragePath { get; set; }

        public string ConnectionString { get; set; }

        public LogLevel LogLevel { get; set; } = LogLevel.Debug;

        public JobLoggerConfiguration(NameValueConfigurationCollection appSettingsCollection)
        {
            LogToDb = TryGetBoolean(appSettingsCollection, "LogToDB");
            LogToFile = TryGetBoolean(appSettingsCollection, "LogToFile");
            LogToConsole = TryGetBoolean(appSettingsCollection, "LogToConsole");
            StoragePath = appSettingsCollection["JobLogger:StoragePath"]?.Value;
            ConnectionString = appSettingsCollection["JobLogger:ConnectionString"]?.Value;

            if(TryGetLogLevel(appSettingsCollection, out var logLevel))
                LogLevel = logLevel;
            
            if (!LogToDb && !LogToConsole && !LogToFile)
                throw new ConfigurationErrorsException("Invalid Configuration. You should choose at least one destination to log");
        }

        private static bool TryGetBoolean(NameValueConfigurationCollection collection, string keyName)
        {
            var rawValue = collection[$"JobLogger:{keyName}"];

            if (rawValue == null || string.IsNullOrWhiteSpace(rawValue.Value))
                return false;

            var canParse = bool.TryParse(rawValue.Value, out var result);

            return canParse && result;
        }

        private static bool TryGetLogLevel(NameValueConfigurationCollection collection, out LogLevel logLevel)
        {
            var rawValue = collection["JobLogger:LogLevel"];

            logLevel = LogLevel.Debug;

            if (rawValue == null || string.IsNullOrWhiteSpace(rawValue.Value))
                return false;

            var canParse = Enum.TryParse(rawValue.Value, true, out logLevel);

            return canParse;
        }
    }
}
