public class Book : Entity
{
    public Book(string title, DateTime? createdDate = default) : base(createdDate)
    {
        Title = title;
    }

    public string Title
    {
        set;
        get;
    }

}