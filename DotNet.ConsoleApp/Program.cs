using DotNet.DAL;
using DotNet.Models;
using DotNet.Services;
using DotNet.Services.Analyzares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;

namespace DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logPath = ConfigurationManager.AppSettings["LogPath"];
            BookRepository bookRepository = PopulateDatabase();
            OrderRepository orderRepository = new OrderRepository();
            var orderService = new OrderService(orderRepository, bookRepository);

            var order = new Order();
            order.BooksOrderedList.Add(new BookOrdered()
            {
                BookId = 1,
                NumberOrdered = 5
            });
            order.BooksOrderedList.Add(new BookOrdered()
            {
                BookId = 3,
                NumberOrdered = 1
            });

            //TO DO: Dodać obsługę wyjątków
            orderService.PlaceOrder(order);

            //Analyze(logPath, bookRepository);

            Console.ReadKey();
        }

        private static void Analyze(string logPath, BookRepository bookRepository)
        {
            var analyzators = new List<IAnalyzator>();
            analyzators.Add(new ZeroProductsAvailaibleAnalyzator(bookRepository));
            analyzators.Add(new TooMuchProductsAvailableAnalyzer(bookRepository));

            var entryAssembly = Assembly.GetEntryAssembly();

            BookWarningManager warningManager = new BookWarningManager(analyzators, logPath);
            var warnings = warningManager.Warn();

            foreach (var warning in warnings)
            {
                var text1 = String.Format("Ostrzeżenie: \n" +
                                           "Message: {0}, \n" +
                                           "Book: {1} \n" +
                                           "############################",
                                            warning.Message, warning.Book);

                var text = $"Ostrzeżenie: \n" +
                            "Message: {warning.Message}, \n" +
                            "Book: {warning.Book}, \n" +
                            "############################";
                Console.WriteLine(text);
            }
        }

        private static BookRepository PopulateDatabase()
        {
            var books = new List<Book>()
            {
                new Book("Stary człowiek i morze", "Ernest Hemingway", 1986, "AAAA", 10, 19.99m),
                new Book("Komu bije dzwon", "Ernest Hemingway", 1997, "BBBB", 0, 119.99m),
                //new Book("Alicja w krainie czarów", "C.K. Lewis", 1998, "CCCC", 53, 39.99m),
                new Book("Opowieści z Narnii", "C.K. Lewis", 1999, "DDDD", 33, 49.99m),
                new Book("Harry Potter", "J.K. Rowling", 2000, "EEEE", 23, 69.99m),
                new Book("Paragraf 22", "Joseph Heller", 2001, "FFFF", 5, 45.99m),
                new Book("Lalka", "Bolesław Prus", 2002, "GGGG", 7, 76.99m),
                new Book("To", "Stephen King", 2003, "HHHH", 2, 12.99m),
                //new Book("Idiota", "Fiodor Dostojewski", 1950, "IIII", 89, 25.99m),
                new Book("Mistrz i Małgorzata", "Michaił Bułhakow", 1965, "JJJJ", 41, 36.99m),
            };

            var booksRepository = new BookRepository();
            foreach (var book in books)
                booksRepository.Insert(book);

            return booksRepository;
        }
    }
}
