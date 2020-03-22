using NLog;

namespace BLL.Implementation
{
    public class LogAdapter
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Log(string message)
        {
            logger.Info(message);
        }
    }
}
