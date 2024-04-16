public class Library
{
    public Library()
    {
        Books = new List<Book>();
        Users = new List<User>();
    }

    public List<Book> Books
    {
        get;
        private set;
    }
    public List<User> Users
    {
        get;
        private set;
    }

    public Book FindBookByTitle(string title)
    {
        var foundedBook = Books.FirstOrDefault((book) => book.Title == title);
        return foundedBook ?? throw new ArgumentException("Book Not Found");
    }

    public User FindUserByName(string name)
    {
        var foundedUser = Users.FirstOrDefault((user) => user.Name == name);
        return foundedUser ?? throw new ArgumentException("User Not Found");
    }

    public void AddBook(Book newBook)
    {

        if (newBook == null)
        {
            throw new ArgumentException("The book object cannot be null");
        }

        if (!Books.Exists((book) => book.Title == newBook.Title))
        {
            Books.Add(newBook);
            Console.WriteLine("Book added successfully!");
        }
        else
        {
            throw new ArgumentException("A book with the same title already exists");
        }

    }

    public void AddUser(User newUser)
    {

        if (newUser == null)
        {
            throw new ArgumentException("The user object cannot be null");
        }

        if (!Users.Exists((user) => user.Name == newUser.Name))
        {
            Users.Add(newUser);
            Console.WriteLine("User added successfully!");
        }
        else
        {
            throw new ArgumentException("A User with the same name already exists");
        }

    }
}