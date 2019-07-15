public class Logger
{
   
     public static void Log(Exception exception)
    {
        Log(exception, EventLogEntryType.Error);
    }
    public static void Log(Exception exception, EventLogEntryType eventLogEntryType)
    {
     do
     {
         sbExceptionMessage.Append("Exception Type" + Environment.NewLine);
         sbExceptionMessage.Append(exception.GetType().Name);
         sbExceptionMessage.Append(Environment.NewLine + Environment.NewLine);
         sbExceptionMessage.Append("Message" + Environment.NewLine);
         sbExceptionMessage.Append(exception.Message + Environment.NewLine + Environment.NewLine);
         sbExceptionMessage.Append("Stack Trace" + Environment.NewLine);
         sbExceptionMessage.Append(exception.StackTrace + Environment.NewLine + Environment.NewLine);

         exception = exception.InnerException;
     }
     while (exception != null);
        
        if (EventLog.SourceExists("CustomEventSource"))
        {            
            EventLog log = new EventLog("MyEventSource");            
            log.Source = "CustomEventSource";            
            log.WriteEntry(sbExceptionMessage.ToString(), eventLogEntryType);
        }
    }
    
    
    
}

////// Global.asax Application_Error() :
if (Server.GetLastError() != null)
{    
    Logger.Log(Server.GetLastError());      <<<<<<<<<<<<<<<<<<<<<<<<<
    Server.ClearError();    
    Server.Transfer("Errors.aspx");
}
