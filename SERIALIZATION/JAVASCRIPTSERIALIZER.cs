


JavaScriptSerializer jss= new JavaScriptSerializer();

var json = jss.Serialize(obj);

User user = jss.Deserialize<User>(jsonResponse); 
 
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


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

    public T Deseralize(string stringObject)
    {
        return this.s.Deserialize<T>(stringObject);
    }
}

 
