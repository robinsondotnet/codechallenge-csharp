using System;
using System.IO;
using System.Runtime.InteropServices;
using CodeChallenge.Infrastructure;
using CodeChallenge.JobLogger.Sinks;
using Moq;
using Xunit;

namespace CodeChallenge.UnitTests.JobLogger
{
    public class LogFileSinkTests
    {
        private readonly ITimeProvider _timeProvider = new Mock<ITimeProvider>().Object;

        [Fact]
        public void ShouldThrowDirectoryNotFoundException_WhenStoragePathItsNotValid()
            => Assert.Throws<DirectoryNotFoundException>(() =>
            {
                var _ = new LogFileSink(_timeProvider, String.Empty);
            });
    }
}
