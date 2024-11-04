using MediaMakerCalculator.Data;

namespace MediaMakerCalculator.Models.Interfaces
{
    public interface ILogHelper
    {
        public void LogItem(string logMessage, string logType, LoggingDbContext context);
    }
}
