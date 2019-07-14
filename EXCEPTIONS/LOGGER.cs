public class Logger
{
    public static void Log(Exception exception)
    {
        
        StringBuilder sbExceptionMessage = new StringBuilder();
        sbExceptionMessage.Append("Exception Type" + Environment.NewLine);        
        sbExceptionMessage.Append(exception.GetType().Name);       
        sbExceptionMessage.Append(Environment.NewLine + Environment.NewLine);
        sbExceptionMessage.Append("Message" + Environment.NewLine);        
        sbExceptionMessage.Append(exception.Message + Environment.NewLine + Environment.NewLine);
        sbExceptionMessage.Append("Stack Trace" + Environment.NewLine);        
        sbExceptionMessage.Append(exception.StackTrace + Environment.NewLine + Environment.NewLine);
        
        Exception innerException = exception.InnerException;         <<<<<<<<<<<<<<<<<<<<<<
        while (innerException != null)                 <<<<<<<<<<<<<<<<<<<<<<
        {
            sbExceptionMessage.Append("Exception Type" + Environment.NewLine);
            sbExceptionMessage.Append(innerException.GetType().Name);
            sbExceptionMessage.Append(Environment.NewLine + Environment.NewLine);
            sbExceptionMessage.Append("Message" + Environment.NewLine);
            sbExceptionMessage.Append(innerException.Message + Environment.NewLine + Environment.NewLine);
            sbExceptionMessage.Append("Stack Trace" + Environment.NewLine);
            sbExceptionMessage.Append(innerException.StackTrace + Environment.NewLine + Environment.NewLine);
           
            innerException = innerException.InnerException;   <<<<<<<<<<<<<<<<<<<<<<<
        }
      
        if (EventLog.SourceExists("MyEventSource"))
        {            
            EventLog log = new EventLog("PragimTech");           
            log.Source = "PragimTech.com";            
            log.WriteEntry(sbExceptionMessage.ToString(), EventLogEntryType.Error);
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
