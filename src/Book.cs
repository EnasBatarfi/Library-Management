public class Book : Entity
{
    public Book(string title, DateTime? createdDate = default) : base(createdDate)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Book title cannot be null or empty");
        }
        Title = title;
    }

    public string Title
    {
        set;
        get;
    }

}