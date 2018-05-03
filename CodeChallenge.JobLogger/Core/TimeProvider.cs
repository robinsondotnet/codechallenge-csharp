using System;
using CodeChallenge.Infrastructure;

namespace CodeChallenge.JobLogger.Core
{
    internal class TimeProvider : ITimeProvider
    {
        private readonly TimeZoneInfo _timeZoneInfo;

        public TimeProvider(TimeZoneInfo timeZoneInfo)
        {
            _timeZoneInfo = timeZoneInfo;
        }

        public string AppendTime(string message)
            => $"[{TimeZoneInfo.ConvertTime(DateTime.Now, _timeZoneInfo).Date:dd/MM/yyyy}] {message}";

        public string GetShortDate()
            => TimeZoneInfo.ConvertTime(DateTime.Now, _timeZoneInfo).Date.ToString("dd/MM/yyyy");
    }
}