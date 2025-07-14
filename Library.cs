using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementApp
{
    // ENUM to represent book genre
    enum Genre { Fiction, NonFiction, SciFi, Biography, Mystery }

    // STRUCT to hold Date info for return date
    struct ReturnDate
    {
        public int DaysFromNow;
        public DateTime GetDate() => DateTime.Now.AddDays(DaysFromNow);
    }

    // INTERFACE for basic person role
    interface IUser
    {
        void DisplayInfo();
    }

    // ABSTRACT CLASS
    abstract class BookBase
    {
        public string Title { get; set; }
        public Genre BookGenre { get; set; }
        public abstract void DisplayBookInfo();
    }

    // INHERITED CLASS
    class Book : BookBase
    {
        public string Author { get; set; }
        public bool IsBorrowed { get; set; } = false;

        public override void DisplayBookInfo()
        {
            Console.WriteLine($"📚 {Title} by {Author} [{BookGenre}] - {(IsBorrowed ? "Not Available" : "Available")}");
        }
    }

    // USER CLASS IMPLEMENTING INTERFACE
    class User : IUser
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; } = new List<Book>();

        public void DisplayInfo()
        {
            Console.WriteLine($"👤 User: {Name}, Books Borrowed: {BorrowedBooks.Count}");
        }

        public void BorrowBook(Book book)
        {
            if (book.IsBorrowed)
            {
                Console.WriteLine("❌ Book is already borrowed.");
                return;
            }

            book.IsBorrowed = true;
            BorrowedBooks.Add(book);
            ReturnDate r = new ReturnDate { DaysFromNow = 7 };
            Console.WriteLine($"✅ Book borrowed! Return by {r.GetDate().ToShortDateString()}");
        }

        public void ReturnBook(string title)
        {
            Book book = BorrowedBooks.FirstOrDefault(b => b.Title.ToLower() == title.ToLower());

            if (book == null)
            {
                Console.WriteLine("❌ Book not found in borrowed list.");
                return;
            }

            book.IsBorrowed = false;
            BorrowedBooks.Remove(book);
            Console.WriteLine("✅ Book returned.");
        }
    }

    // STATIC LIBRARY CLASS
    static class Library
    {
        public static List<Book> Books = new List<Book>();
        public static List<User> Users = new List<User>();

        public static void SeedData()
        {
            Books.AddRange(new List<Book> {
                new Book { Title = "Atomic Habits", Author = "James Clear", BookGenre = Genre.NonFiction },
                new Book { Title = "Dune", Author = "Frank Herbert", BookGenre = Genre.SciFi },
                new Book { Title = "Sherlock Holmes", Author = "Arthur Conan Doyle", BookGenre = Genre.Mystery }
            });

            Users.Add(new User { Name = "Ryan" });
        }

        public static void ListBooks()
        {
            Console.WriteLine("\n📚 All Books:");
            foreach (var book in Books)
                book.DisplayBookInfo();
        }

        public static void ListUsers()
        {
            Console.WriteLine("\n👥 Registered Users:");
            foreach (var user in Users)
                user.DisplayInfo();
        }

        public static User GetUser(string name)
        {
            return Users.FirstOrDefault(u => u.Name.ToLower() == name.ToLower());
        }

        public static Book GetBook(string title)
        {
            return Books.FirstOrDefault(b => b.Title.ToLower() == title.ToLower());
        }
    }

    class Library
    {
        static void Main(string[] args)
        {
            Library.SeedData();

            Console.WriteLine("📖 Welcome to the Library Management System\n");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. View all books");
                Console.WriteLine("2. Register new user");
                Console.WriteLine("3. Borrow book");
                Console.WriteLine("4. Return book");
                Console.WriteLine("5. View users");
                Console.WriteLine("6. Exit");

                Console.Write("👉 Enter choice: ");
                string input = Console.ReadLine();

                try
                {
                    switch (input)
                    {
                        case "1":
                            Library.ListBooks();
                            break;

                        case "2":
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();
                            if (Library.GetUser(name) != null)
                                Console.WriteLine("⚠️ User already exists.");
                            else
                            {
                                Library.Users.Add(new User { Name = name });
                                Console.WriteLine("✅ User registered.");
                            }
                            break;

                        case "3":
                            Console.Write("Enter your name: ");
                            string borrower = Console.ReadLine();
                            User user = Library.GetUser(borrower);
                            if (user == null) { Console.WriteLine("❌ User not found."); break; }

                            Console.Write("Enter book title: ");
                            string title = Console.ReadLine();
                            Book bookToBorrow = Library.GetBook(title);
                            if (bookToBorrow == null) { Console.WriteLine("❌ Book not found."); break; }

                            user.BorrowBook(bookToBorrow);
                            break;

                        case "4":
                            Console.Write("Enter your name: ");
                            string returner = Console.ReadLine();
                            User returningUser = Library.GetUser(returner);
                            if (returningUser == null) { Console.WriteLine("❌ User not found."); break; }

                            Console.Write("Enter book title: ");
                            string returnTitle = Console.ReadLine();
                            returningUser.ReturnBook(returnTitle);
                            break;

                        case "5":
                            Library.ListUsers();
                            break;

                        case "6":
                            Console.WriteLine("👋 Exiting... Goodbye!");
                            return;

                        default:
                            Console.WriteLine("❌ Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("⚠️ Error occurred: " + ex.Message);
                }
            }
        }
    }
}
