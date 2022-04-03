using NLog;

namespace RegisterAndLoginApp.Services.Utility
{
    public class MyLogger : Ilogger
    {
        private static MyLogger instance;
        private static Logger logger;

        public static MyLogger GetInstance() 
        {
            if (instance == null)
                instance = new MyLogger();
            return instance;
        }

        private Logger GetLogger() 
        {
            if (MyLogger.logger == null)
                MyLogger.logger = LogManager.GetLogger("LoginAppLoggerrule");
            return MyLogger.logger;
        }
        public void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        public void Error(string message)
        {
            GetLogger().Error(message);
        }

        public void Info(string message)
        {
            GetLogger().Info(message);
        }

        public void Warn(string message)
        {
            GetLogger().Warn(message);
        }
    }
}
