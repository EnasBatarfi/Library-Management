public class Library
{
    INotificationService notificationService;
    public Library(INotificationService notificationService)
    {
        this.notificationService = notificationService;
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

    public List<Book> FindBooksByTitle(string title)
    {
        var foundedBooks = Books.FindAll((book) => book.Title.Contains(title));
        return foundedBooks.Count == 0 ? throw new ArgumentException("Books Not Found") : foundedBooks;
    }

    public List<User> FindUsersByName(string name)
    {
        var foundedUsers = Users.FindAll((user) => user.Name.Contains(name));
        return foundedUsers.Count == 0 ? throw new ArgumentException("User Not Found") : foundedUsers;
    }

    public void AddBook(Book newBook)
    {

        // if (newBook == null)
        // {
        //     notificationService.SendNotificationOnFailure("Failed to add book. The book object cannot be null");
        //     throw new ArgumentException("The book object cannot be null");
        // }

        if (!Books.Exists((book) => book.Title == newBook.Title))
        {
            Books.Add(newBook);
            notificationService.SendNotificationOnSuccess($"Book '{newBook.Title}' added to Library");
        }
        else
        {
            notificationService.SendNotificationOnFailure($"Failed to add book '{newBook.Title}'. A book with the same title already exists");
            throw new ArgumentException("A book with the same title already exists");

        }
    }

    public void AddUser(User newUser)
    {

        // if (newUser == null)
        // {
        //     notificationService.SendNotificationOnFailure("Failed to add user. The user object cannot be null");
        //     throw new ArgumentException("The user object cannot be null");
        // }

        Users.Add(newUser);
        Users.Add(newUser);
        notificationService.SendNotificationOnSuccess($"User '{newUser.Name}' added to Library");
    }

    public void DeleteBook(string id)
    {
        var bookToBeDeleted = Books.Find((book) => book.Id == id);

        if (bookToBeDeleted != null)
        {
            string deletedBookName = bookToBeDeleted.Title;
            Books.Remove(bookToBeDeleted);
            notificationService.SendNotificationOnSuccess($"Book '{deletedBookName}' deleted successfully!");
        }
        else
        {
            notificationService.SendNotificationOnFailure("Failed to delete book. Book not found.");
            throw new ArgumentException("Book Not Found");
        }
    }

    public void DeleteUser(string id)
    {
        var userToBeDeleted = Users.Find((user) => user.Id == id);

        if (userToBeDeleted != null)
        {
            string deletedUserName = userToBeDeleted.Name;
            Users.Remove(userToBeDeleted);
            notificationService.SendNotificationOnSuccess($"User '{deletedUserName}' deleted successfully!");
        }
        else
        {
            notificationService.SendNotificationOnFailure("Failed to delete user. User not found.");
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

    public void UpdateCopiesNo(string title, int newCopiesNo)
    {
        var bookToBeUpdated = Books.Find((book) => book.Title == title);

        if (bookToBeUpdated != null)
        {
            bookToBeUpdated.Copies = newCopiesNo;
            Console.WriteLine("Book copies number updated successfully!");
        }
        else
        {
            throw new ArgumentException("Book Not Found");
        }


    }
}