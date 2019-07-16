public static void SendEmail(string emailbody)
{
  
    MailMessage mailMessage = new MailMessage("from_email@gmail.com", "To_Email@gmail.com");
   
    mailMessage.Body = emailbody;
   
    mailMessage.Subject = "Exception";

    
    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);   <<<<<<<<<  GMAIL
    
    smtpClient.Credentials = new System.Net.NetworkCredential() 
    { 
        UserName = ConfigurationManager.AppSettings["UserName"], Password = ConfigurationManager.AppSettings["Password"]
    };
    // Gmail works on SSL
    smtpClient.EnableSsl = true;
   
    smtpClient.Send(mailMessage);
} 


<appSettings>
  <add key="UserName" value=""/>
  <add key="Password" value=""/>
</appSettings>
