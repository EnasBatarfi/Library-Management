public class User : LibraryEntity
{
    public User(string name, DateTime? createdDate = default) : base(createdDate)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("User name cannot be null or empty");
        }
        Name = name;
    }
    public string Name
    {
        set;
        get;
    }
}