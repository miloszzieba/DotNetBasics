using DotNet.DAL;
using DotNet.Models;
using DotNet.Services;
using DotNet.Services.Analyzares;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BookRepository bookRepository = PopulateDatabase();

            var analyzators = new List<IAnalyzator>();
            analyzators.Add(new ZeroProductsAvailaibleAnalyzator(bookRepository));
            analyzators.Add(new TooMuchProductsAvailableAnalyzer(bookRepository));

            BookWarningManager warningManager = new BookWarningManager(analyzators);
            var warnings = warningManager.Warn();

            foreach (var warning in warnings)
            {

                Console.WriteLine("Ostrzeżenie:");
                Console.WriteLine(warning.Message);
                Console.WriteLine(warning.Book);
                System.Console.WriteLine("##########");
            }

            Console.ReadKey();
        }

        private static BookRepository PopulateDatabase()
        {
            var books = new List<Book>()
            {
                new Book("Stary człowiek i morze", "Ernest Hemingway", 1986, "AAAA", 10, 19.99m),
                new Book("Komu bije dzwon", "Ernest Hemingway", 1997, "BBBB", 0, 119.99m),
                new Book("Alicja w krainie czarów", "C.K. Lewis", 1998, "CCCC", 53, 39.99m),
                new Book("Opowieści z Narnii", "C.K. Lewis", 1999, "DDDD", 33, 49.99m),
                new Book("Harry Potter", "J.K. Rowling", 2000, "EEEE", 23, 69.99m),
                new Book("Paragraf 22", "Joseph Heller", 2001, "FFFF", 5, 45.99m),
                new Book("Lalka", "Bolesław Prus", 2002, "GGGG", 7, 76.99m),
                new Book("To", "Stephen King", 2003, "HHHH", 2, 12.99m),
                new Book("Idiota", "Fiodor Dostojewski", 1950, "IIII", 89, 25.99m),
                new Book("Mistrz i Małgorzata", "Michaił Bułhakow", 1965, "JJJJ", 41, 36.99m),
            };

            var booksRepository = new BookRepository();
            foreach (var book in books)
                booksRepository.Insert(book);

            return booksRepository;
        }
    }
}
