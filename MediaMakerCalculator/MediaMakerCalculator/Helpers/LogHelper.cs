using MediaMakerCalculator.Data;
using MediaMakerCalculator.Models;
using MediaMakerCalculator.Models.Interfaces;
using SQLitePCL;

namespace MediaMakerCalculator.Helpers
{
    // Logs events to the SQLite database
    public class LogHelper : ILogHelper
    {
        public void LogItem(string logMessage, string logType, LoggingDbContext context)
        {
            context.LogItems.Update(new LogItem()
            {
                LogMessage = logMessage,
                LogType = logType,
                LogTime = DateTime.Now.ToString()
            });
            context.SaveChanges();
        }
    }
}