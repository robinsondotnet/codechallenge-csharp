using CodeChallenge.Data.Model;
using CodeChallenge.Data.Sql;
using CodeChallenge.Infrastructure;

namespace CodeChallenge.JobLogger.Sinks
{
    public class DbStorageSink : LogSink
    {
        private readonly IRepository<Log> _repository;

        public DbStorageSink(string connectionString)
        {
            _repository = new LogRepository(connectionString);
        }

        private void WriteToDb(Log log)
            => _repository.Insert(log);

        public override void LogWarning(string message)
            => WriteToDb(new Log { LogLevel = (int) LogLevel.Warning, Message = message});

        public override void LogError(string message)
            => WriteToDb(new Log { LogLevel = (int) LogLevel.Error, Message = message});

        public override void LogMessage(string message)
            => WriteToDb(new Log { LogLevel = (int)LogLevel.Message, Message = message });

        public override void LogDebug(string message)
            => WriteToDb(new Log { LogLevel = (int)LogLevel.Debug, Message = message });
    }
}
