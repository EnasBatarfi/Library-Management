using System.Dynamic;

public class Book
{
    public Book(string id, string title, DateTime createdDate)
    {
        Id = id;
        Title = title;
        CreatedDate = createdDate;
    }
    public string Id
    {
        set;
        get;
    }
    public string Title
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