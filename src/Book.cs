public class Book : LibraryEntity
{
    public Book(string title, DateTime? createdDate = default, int copies = 1) : base(createdDate)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Book title cannot be null or empty");
        }
        Title = title;
        Copies = copies;
    }
    //adding copies of the book and check the existence by the title? may be also i can add the edition of the book or version?
    public string Title
    {
        set;
        get;
    }
    public int Copies
    {
        set;
        get;
    }
}