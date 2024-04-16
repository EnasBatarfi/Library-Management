public class User : Entity
{
    public User(string name, DateTime? createdDate = default) : base(createdDate)
    {
        Name = name;
    }
    public string Name
    {
        set;
        get;
    }
}