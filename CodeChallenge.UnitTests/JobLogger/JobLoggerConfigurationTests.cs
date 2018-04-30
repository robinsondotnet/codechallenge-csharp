using System.Configuration;
using CodeChallenge.JobLogger.Core;
using Xunit;

namespace CodeChallenge.UnitTests
{
    public class JobLoggerConfigurationTests
    {
        [Fact]
        public void ShouldSetFalseValue_WhenItsNotConfigured()
        {
            var appSettings = new NameValueConfigurationCollection {["JobLogger:LogToFile"] = {Value = "true"}};

            var loggerConfiguration = new JobLoggerConfiguration(appSettings);

            Assert.True(loggerConfiguration.LogToFile); 
            Assert.False(loggerConfiguration.LogToConsole);
            Assert.False(loggerConfiguration.LogToDb);
        }

        [Fact]
        public void ShouldThrowException_WhenAllValuesAreFalse() => Assert.Throws<ConfigurationErrorsException>(() =>
        {
            var _ = new JobLoggerConfiguration(new NameValueConfigurationCollection());
        });
    }
}
