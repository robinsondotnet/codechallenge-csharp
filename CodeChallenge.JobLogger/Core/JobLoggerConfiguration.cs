﻿using System.Configuration;

namespace CodeChallenge.JobLogger.Core
{
    public class JobLoggerConfiguration
    {
        public bool LogToDb { get; set; }

        public bool LogToFile { get; set; }

        public bool LogToConsole { get; set; }

        public string StoragePath { get; set; }

        public string ConnectionString { get; set; }

        public JobLoggerConfiguration(NameValueConfigurationCollection appSettingsCollection)
        {
            LogToDb = TryGet(appSettingsCollection, "LogToDB");
            LogToFile = TryGet(appSettingsCollection, "LogToFile");
            LogToConsole = TryGet(appSettingsCollection, "LogToConsole");
            StoragePath = appSettingsCollection["JobLogger:StoragePath"]?.Value;
            ConnectionString = appSettingsCollection["JobLogger:ConnectionString"]?.Value;
            
            if (!LogToDb && !LogToConsole && !LogToFile)
                throw new ConfigurationErrorsException("Invalid Configuration. You should choose at least one destination to log");
        }

        private static bool TryGet(NameValueConfigurationCollection collection, string keyName)
        {
            var rawValue = collection[$"JobLogger:{keyName}"];

            if (rawValue == null || string.IsNullOrWhiteSpace(rawValue.Value))
                return false;

            var canParse = bool.TryParse(rawValue.Value, out var result);

            return canParse && result;
        }
    }
}
