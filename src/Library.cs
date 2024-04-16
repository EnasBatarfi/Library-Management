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

    public List<Book> FindBookByTitle(string title)
    {
        var foundedBooks = Books.FindAll((book) => book.Title.Contains(title));
        // return foundedBooks.Count == 0 ? throw new ArgumentException("Books Not Found") : foundedBooks;
        return foundedBooks;
    }

    public List<User> FindUserByName(string name)
    {
        var foundedUsers = Users.FindAll((user) => user.Name.Contains(name));
        // return foundedUsers ?? throw new ArgumentException("User Not Found");
        return foundedUsers;
    }

    public void AddBook(Book newBook)
    {

        if (newBook == null)
        {
            throw new ArgumentException("The book object cannot be null");
        }

        Books.Add(newBook);
        Console.WriteLine("Book added successfully!");
    }

    public void AddUser(User newUser)
    {

        if (newUser == null)
        {
            throw new ArgumentException("The user object cannot be null");
        }

        Users.Add(newUser);
        Console.WriteLine("User added successfully!");
    }

    public void DeleteBook(string id)
    {
        var bookToBeDeleted = Books.Find((book) => book.Id == id);

        if (bookToBeDeleted != null)
        {
            Books.Remove(bookToBeDeleted);
            Console.WriteLine("Book deleted successfully!");
        }
        else
        {
            throw new ArgumentException("Book Not Found");
        }

    }
    public void DeleteUser(string id)
    {
        var userToBeDeleted = Users.Find((user) => user.Id == id);

        if (userToBeDeleted != null)
        {
            Users.Remove(userToBeDeleted);
            Console.WriteLine("User deleted successfully!");
        }
        else
        {
            throw new ArgumentException("User Not Found");
        }

    }

    public List<Book> GetAllBooks(int pageNo, int limitPerPage)
    {
        return Books.Skip((pageNo - 1) * limitPerPage).Take(limitPerPage).OrderBy(book => book.CreatedDate).ToList();
    }
    public List<User> GetAllUsers(int pageNo, int limitPerPage)
    {
        return Users.Skip((pageNo - 1) * limitPerPage).Take(limitPerPage).OrderBy(user => user.CreatedDate).ToList();
    }
}