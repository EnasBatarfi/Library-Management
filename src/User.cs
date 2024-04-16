public class User
{
    public User(string id, string name, DateTime createdDate)
    {
        Id = id;
        Name = name;
        CreatedDate = createdDate;
    }
    public string Id
    {
        set;
        get;
    }
    public string Name
    {
        set;
        get;
    }
    public DateTime CreatedDate
    {
        set;
        get;
    }
}