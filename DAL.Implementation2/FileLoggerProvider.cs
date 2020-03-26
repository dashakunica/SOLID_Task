using System;
using System.IO;
using DAL.Contract;
using Microsoft.Extensions.Logging;

namespace DAL.Implementaion2
{
    public class FileLoggerProvider : ILoggerProvider<Microsoft.Extensions.Logging.ILogger>
    {
        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return new FileLogger();
        }

        public void Dispose()
        {
        }

        private class FileLogger : Microsoft.Extensions.Logging.ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId,
                TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                File.AppendAllText("log.txt", formatter(state, exception));
                Console.WriteLine(formatter(state, exception));
            }

            public void Log(string message)
            {
                throw new NotImplementedException();
            }
        }
    }
}
