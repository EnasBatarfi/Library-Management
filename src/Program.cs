namespace LibraryManagement;
using System;

public class LibraryManagementApp
{
    public static void Main(string[] args)
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                Welcome to the Library Management System!              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
        Console.Write("\n\nHow would you like to receive notifications?\n1. SMS message\n2. Email message\nEnter '1' for SMS or '2' for Email: ");
        int notificationsChoice;
        while (!int.TryParse(Console.ReadLine(), out notificationsChoice) || notificationsChoice < 1 || notificationsChoice > 2)
        {
            Console.Write("\nInvalid input. Please enter '1' for SMS or '2' for Email: ");
        }
        INotificationService notificationService = notificationsChoice == 1 ? new SMSNotificationService() : new EmailNotificationService();
        Library library = new Library(notificationService);

        while (true)
        {
            try
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Initialize the store");

                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Add User");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Delete User");
                Console.WriteLine("6. Find Book by Title");
                Console.WriteLine("7. Find User by Name");
                Console.WriteLine("8. Display All Books");
                Console.WriteLine("9. Display All Users");
                Console.WriteLine("10. Update Copies Number");
                Console.WriteLine("11. Exit");
                Console.Write("\nEnter your choice (1-11): ");
                int choice;

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 11)
                {
                    Console.Write("\nInvalid input. Please enter a number between 1 and 11: ");
                }

                switch (choice)
                {
                    case 1:
                        AddInitialValues(library);
                        break;
                    case 2:
                        AddBook(library);
                        break;
                    case 3:
                        AddUser(library);
                        break;
                    case 4:
                        DeleteBook(library);
                        break;
                    case 5:
                        DeleteUser(library);
                        break;
                    case 6:
                        FindBook(library);
                        break;
                    case 7:
                        FindUser(library);
                        break;
                    case 8:
                        DisplayBooks(library);
                        break;
                    case 9:
                        DisplayUsers(library);
                        break;
                    case 10:
                        UpdateCopiesNumber(library);
                        break;
                    case 11:
                        Console.WriteLine("\nThank you for using the Library Management System!");
                        return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nAn error occurred: {e.Message}");
            }
        }
    }
    public static void AddInitialValues(Library library)
    {
        var user1 = new User("Alice", new DateTime(2023, 1, 1));
        var user2 = new User("Bob", new DateTime(2023, 2, 1));
        var user3 = new User("Charlie", new DateTime(2023, 3, 1));
        var user4 = new User("David", new DateTime(2023, 4, 1));
        var user5 = new User("Eve", new DateTime(2024, 5, 1));
        var user6 = new User("Fiona", new DateTime(2024, 6, 1));
        var user7 = new User("George", new DateTime(2024, 7, 1));
        var user8 = new User("Hannah", new DateTime(2024, 8, 1));
        var user9 = new User("Ian");
        var user10 = new User("Julia");

        var book1 = new Book("The Great Gatsby", new DateTime(2023, 1, 1));
        var book2 = new Book("1984", new DateTime(2023, 2, 1));
        var book3 = new Book("To Kill a Mockingbird", new DateTime(2023, 3, 1));
        var book4 = new Book("The Catcher in the Rye", new DateTime(2023, 4, 1));
        var book5 = new Book("Pride and Prejudice", new DateTime(2023, 5, 1));
        var book6 = new Book("Wuthering Heights", new DateTime(2023, 6, 1));
        var book7 = new Book("Jane Eyre", new DateTime(2023, 7, 1));
        var book8 = new Book("Brave New World", new DateTime(2023, 8, 1));
        var book9 = new Book("Moby-Dick", new DateTime(2023, 9, 1));
        var book10 = new Book("War and Peace", new DateTime(2023, 10, 1));
        var book11 = new Book("Hamlet", new DateTime(2023, 11, 1));
        var book12 = new Book("Great Expectations", new DateTime(2023, 12, 1));
        var book13 = new Book("Ulysses", new DateTime(2024, 1, 1));
        var book14 = new Book("The Odyssey", new DateTime(2024, 2, 1));
        var book15 = new Book("The Divine Comedy", new DateTime(2024, 3, 1));
        var book16 = new Book("Crime and Punishment", new DateTime(2024, 4, 1));
        var book17 = new Book("The Brothers Karamazov", new DateTime(2024, 5, 1));
        var book18 = new Book("Don Quixote", new DateTime(2024, 6, 1));
        var book19 = new Book("The Iliad");
        var book20 = new Book("Anna Karenina");

        // Add users to the library
        library.AddUser(user1);
        library.AddUser(user2);
        library.AddUser(user3);
        library.AddUser(user4);
        library.AddUser(user5);
        library.AddUser(user6);
        library.AddUser(user7);
        library.AddUser(user8);
        library.AddUser(user9);
        library.AddUser(user10);

        // Add books to the library
        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);
        library.AddBook(book4);
        library.AddBook(book5);
        library.AddBook(book6);
        library.AddBook(book7);
        library.AddBook(book8);
        library.AddBook(book9);
        library.AddBook(book10);
        library.AddBook(book11);
        library.AddBook(book12);
        library.AddBook(book13);
        library.AddBook(book14);
        library.AddBook(book15);
        library.AddBook(book16);
        library.AddBook(book17);
        library.AddBook(book18);
        library.AddBook(book19);
        library.AddBook(book20);
    }

    private static void AddBook(Library library)
    {
        Console.WriteLine("\nAdd Book:");
        Console.Write("Enter book title: ");
        string title = Console.ReadLine()?.Trim() ?? "";
        DateTime creationDate = DateTime.Now;

        Console.Write("Do you want to specify the creation date? (Y/N): ");
        string specifyDateInput = Console.ReadLine()?.Trim().ToUpper() ?? "";
        if (specifyDateInput == "Y")
        {
            Console.Write("Enter creation date (yyyy-MM-dd) or leave empty for today's date: ");
            while (true)
            {
                string input = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrEmpty(input) && !DateTime.TryParse(input, out creationDate))
                {
                    Console.Write("Invalid date format. Please enter a valid date or leave it empty: ");
                }
                else
                {
                    break;
                }
            }
        }
        int copiesNo = 1;
        Console.Write("Do you want to specify number of copies for the book? (Y/N): ");
        string specifyCopiesNoInput = Console.ReadLine()?.Trim().ToUpper() ?? "";
        if (specifyCopiesNoInput == "Y")
        {
            Console.Write("Enter Number of copies: ");
            while (true)
            {
                string input = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrEmpty(input) && !int.TryParse(input, out copiesNo) && copiesNo > 0)
                {
                    Console.Write("Invalid input format. Please enter a positive integer: ");
                }
                else
                {
                    break;
                }
            }
        }

        library.AddBook(new Book(title, creationDate, copiesNo));
    }

    private static void AddUser(Library library)
    {
        Console.WriteLine("\nAdd User:");
        Console.Write("Enter user name: ");
        string name = Console.ReadLine()?.Trim() ?? "";
        DateTime creationDate = DateTime.Now;

        Console.Write("Do you want to specify the creation date? (Y/N): ");
        string specifyDateInput = Console.ReadLine()?.Trim().ToUpper() ?? "";
        if (specifyDateInput == "Y")
        {
            Console.Write("Enter creation date (yyyy-MM-dd) or leave empty for today's date: ");
            while (true)
            {
                string input = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrEmpty(input) && !DateTime.TryParse(input, out creationDate))
                {
                    Console.Write("Invalid date format. Please enter a valid date or leave it empty: ");
                }
                else
                {
                    break;
                }
            }
        }

        library.AddUser(new User(name, creationDate));
    }

    private static void DeleteBook(Library library)
    {
        Console.Write("\nEnter book ID to delete: ");
        string id = Console.ReadLine() ?? "";
        library.DeleteBook(id);
    }

    private static void DeleteUser(Library library)
    {
        Console.Write("\nEnter user ID to delete: ");
        string id = Console.ReadLine() ?? "";
        library.DeleteUser(id);
    }

    private static void FindBook(Library library)
    {
        Console.Write("\nEnter book title to find: ");
        string title = Console.ReadLine() ?? "";
        var books = library.FindBooksByTitle(title);
        DisplayLibraryEntities(books.Select(book => (LibraryEntity)book).ToList());
    }

    private static void UpdateCopiesNumber(Library library)
    {
        Console.Write("\nEnter book title to update its copies number: ");
        string title = Console.ReadLine()?.Trim() ?? "";

        var book = library.FindBooksByTitle(title).FirstOrDefault();

        if (book != null)
        {
            Console.WriteLine("\nFounded Book:");
            DisplayLibraryEntities(new List<LibraryEntity> { book });

            Console.Write("\nDo you still want to update the copies number for the book? (Y/N): ");
            string confirmation = Console.ReadLine()?.Trim().ToUpper() ?? "";

            if (confirmation == "Y")
            {
                Console.Write("Enter the new number of copies: ");
                int newCopies;
                while (!(int.TryParse(Console.ReadLine(), out newCopies) && newCopies >= 0))
                {
                    Console.Write("Invalid input. The number of copies must be a positive integer: ");
                }
                library.UpdateCopiesNo(book.Title, newCopies);
                Console.WriteLine("\nUpdated Book: ");
                DisplayLibraryEntities(new List<LibraryEntity> { book });

            }
        }

    }


    private static void FindUser(Library library)
    {
        Console.Write("\nEnter user name to find: ");
        string name = Console.ReadLine() ?? "";
        var users = library.FindUsersByName(name);
        DisplayLibraryEntities(users.Select(user => (LibraryEntity)user).ToList());
    }

    private static void DisplayBooks(Library library)
    {
        Console.WriteLine("\nBooks in the library:");

        Console.Write("Enter page number: ");
        int pageNo;
        while (!int.TryParse(Console.ReadLine(), out pageNo) || pageNo < 1)
        {
            Console.Write("Invalid input. Please enter a positive integer for page number: ");
        }

        Console.Write("Enter limit per page: ");
        int limitPerPage;
        while (!int.TryParse(Console.ReadLine(), out limitPerPage) || limitPerPage < 1)
        {
            Console.Write("Invalid input. Please enter a positive integer for limit per page: ");
        }

        var books = library.GetAllBooks(pageNo, limitPerPage);
        DisplayLibraryEntities(books.Select(book => (LibraryEntity)book).ToList());
    }

    private static void DisplayUsers(Library library)
    {
        Console.WriteLine("\nUsers in the library:");

        Console.Write("Enter page number: ");
        int pageNo;
        while (!int.TryParse(Console.ReadLine(), out pageNo) || pageNo < 1)
        {
            Console.Write("Invalid input. Please enter a positive integer for page number: ");
        }

        Console.Write("Enter limit per page: ");
        int limitPerPage;
        while (!int.TryParse(Console.ReadLine(), out limitPerPage) || limitPerPage < 1)
        {
            Console.Write("Invalid input. Please enter a positive integer for limit per page: ");
        }

        var users = library.GetAllUsers(pageNo, limitPerPage);
        DisplayLibraryEntities(users.Select(user => (LibraryEntity)user).ToList());
    }
    public static void DisplayLibraryEntities(List<LibraryEntity> libraryEntities)
    {
        Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine("│                                                           Library Entities Table                                                        │");
        Console.WriteLine("├─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤");

        if (libraryEntities.Count > 0)
        {
            bool includeCopiesColumn = libraryEntities.Any(entity => entity is Book);
            if (includeCopiesColumn)
            {
                Console.WriteLine("│ ID                                       │ Title                                         │ Copies     │ Created Date                    │");
                Console.WriteLine("├──────────────────────────────────────────┼───────────────────────────────────────────────┼────────────┼─────────────────────────────────┤");
            }
            else
            {
                Console.WriteLine("│ ID                                          │ Name                                        │ Created Date                                │");
                Console.WriteLine("├─────────────────────────────────────────────┼─────────────────────────────────────────────┼─────────────────────────────────────────────┤");
            }

            foreach (var entity in libraryEntities)
            {
                string id = entity.Id;
                string titleOrName = "";
                string copies = "";

                if (entity is Book book)
                {
                    titleOrName = book.Title;
                    copies = book.Copies.ToString();
                }
                else if (entity is User user)
                {
                    titleOrName = user.Name;
                }

                if (includeCopiesColumn)
                {
                    Console.WriteLine($"│ {id,-40} │ {titleOrName,-45} │ {copies,-10} │ {entity.CreatedDate,-31} │");
                }
                else
                {
                    Console.WriteLine($"│ {id,-43} │ {titleOrName,-43} │ {entity.CreatedDate,-43} │");
                }
            }
        }
        else
        {
            Console.WriteLine("│                                                         No entities in the library                                                      │");
        }

        Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
    }

}