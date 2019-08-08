string sEncriptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

string sIdentity = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
@@@@@@@@@@@@  
private static string _connectionString = ConfigurationManager.ConnectionStrings["DBBMEntitiesADO"].ConnectionString.ToString();
@@@@@@@@@@@@ USE CONFIGURATION MANAGER :
using System.Configuration;
string sEnvironment = ConfigurationManager.AppSettings["Environment"];
<appSettings>
    <add key="SectionOffset" value="10000" />
    <add  key="Environment" value="Dev"/>

@@@@@@@@@@@@  READ RESPONSE :
string url = "Your request url";
WebRequest request = HttpWebRequest.Create(url);
WebResponse response = request.GetResponse();
StreamReader reader = new StreamReader(response.GetResponseStream());
string responseText = reader.ReadToEnd();

@@@@@@@@@@@@  GET DATA FROM XML FILE :  
DataSet DS = new DataSet();
DS.ReadXml(Server.MapPath("../../Data/Countries/Countries.xml"));
DropDownList1.DataTextField = "CountryName";
DropDownList1.DataValueField = "CountryId";
DropDownList1.DataSource = DS;
DropDownList1.DataBind();   


@@@@@@@@@@@@    GET DATA FROM DB :
 if (!IsPostBack)
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Select CityId, CityName, Country from tblCity", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList1.DataSource = rdr;
            DropDownList1.DataBind();
        }
    }  


@@@@@@@@@@@@    



@@@@@@@@@@@@    



@@@@@@@@@@@@    


@@@@@@@@@@@@    


