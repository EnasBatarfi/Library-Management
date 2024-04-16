public class Library
{
    public Library(Book[] books, User[] users)
    {
        Books = books;
        Users = users;
    }

    public Book[] Books
    {
        get;
        set;
    }
    public User[] Users
    {
        get;
        set;
    }
}