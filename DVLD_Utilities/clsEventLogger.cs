using System.Diagnostics;

namespace DVLD_Utilities
{
    public class clsEventLogger
    {
        private static string SourceName = "DVLD_System";
        private static string LogName = "Application";

        public static void Log(string Message, EventLogEntryType Type)
        {
            try
            {
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, LogName);
                }

                EventLog.WriteEntry(SourceName, Message, Type);
            }
            catch
            {
            }
        }
    }
}
