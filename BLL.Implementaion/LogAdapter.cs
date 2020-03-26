using NLog;
using Bll.Contract;

namespace BLL.Implementation2
{
    public class LogAdapter : Bll.Contract.ILogger
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Log(string message)
        {
            logger.Info(message);
        }
    }
}
