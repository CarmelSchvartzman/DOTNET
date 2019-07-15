Create table tblLog
(
 [Id] int primary key identity(1,1),
 [Date] DateTime,
 [ExceptionMessage] nvarchar(max)
) 


create procedure spInsertLog
@ExceptionMessage nvarchar(max)
as
begin
 insert into tblLog([Date], [ExceptionMessage])
 values (Getdate(), @ExceptionMessage)
end


<connectionStrings>
  <add name="DBConnectionString"
  connectionString="data source=.; database=Sample; Integrated Security=SSPI"
  providerName="System.Data.SqlClient" />
</connectionStrings> 


public class Logger
{
    public static void Log(Exception exception)
    {
        StringBuilder sbExceptionMessage = new StringBuilder();

        do
        {
            sbExceptionMessage.Append("Exception Type" + Environment.NewLine);
            sbExceptionMessage.Append(exception.GetType().Name);
            sbExceptionMessage.Append(Environment.NewLine + Environment.NewLine);
            sbExceptionMessage.Append("Message" + Environment.NewLine);
            sbExceptionMessage.Append(exception.Message + Environment NewLine + Environment.NewLine);
            sbExceptionMessage.Append("Stack Trace" + Environment.NewLine);
            sbExceptionMessage.Append(exception.StackTrace + Environment NewLine + Environment.NewLine);

            exception = exception.InnerException;
        }
        while (exception != null);
        
        LogToDB(sbExceptionMessage.ToString());
    }

    private static void LogToDB(string log)
    {
       
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;       
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("spInsertLog", con);           
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@ExceptionMessage", log);
            cmd.Parameters.Add(parameter);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
