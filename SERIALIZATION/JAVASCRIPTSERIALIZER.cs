using System.Web.Script.Serialization;


JavaScriptSerializer jss= new JavaScriptSerializer();

var json = jss.Serialize(obj);

User user = jss.Deserialize<User>(jsonResponse); 
 
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
using System.Web.Script.Serialization;

public class Serializer<T>
{
    private readonly JavaScriptSerializer s;

    public Serializer()
    {
        this.s = new JavaScriptSerializer();
    }

    public string Serialize(T t)
    {
        return this.s.Serialize(t);
    }

    public T Deserialize(string stringObject)
    {
        return this.s.Deserialize<T>(stringObject);
    }
}

 
