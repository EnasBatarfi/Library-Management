public class LibraryEntity
{
    public LibraryEntity(DateTime? createdDate = default)
    {
        Id = Guid.NewGuid().ToString();
        CreatedDate = createdDate ?? DateTime.Now;
    }
    public string Id
    {
        get;
        set;
    }
    public DateTime CreatedDate
    {
        get;
        set;
    }
}