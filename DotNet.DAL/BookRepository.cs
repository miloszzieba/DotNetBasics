using DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.DAL
{
    public sealed class BookRepository : BaseRepository<Book>
    {
        public List<decimal> GetBookPrices()
        {
            return _database.Select(x => new
            {
                x.Author,
                x.Price,
                Rabat = x.ProductsAvailable > 50 ? 20 : 0,
                Dodatek = x.ProductsAvailable < 10 ? 10 : 0
            })
            .Select(x => new
            {
                Price = x.Price * (100 + x.Dodatek - x.Rabat) /100,
                VAT = x.Author.Length > 20 ? 23 : 8
            })
            .Select(x => x.Price * (100 + x.VAT)/100)
            .ToList();
        }

        public void RemoveByISBN(string isbn)
        {
            this._database.RemoveAll(book => book.ISBN == isbn);
        }

        public List<Book> GetByAuthor(string author)
        {
            return this._database.Where(x => x.Author == author)
                .ToList();
        }

       

        public Book GetByISBN(string isbn)
        {
            return this._database.SingleOrDefault(book => book.ISBN == isbn);
        }

        public List<Book> GetByTitle(string title)
        {
            return this._database.Where(x => x.Title == title)
                .ToList();
        }
       

        public void DecreaseProductsAvailable(int bookId, int numberOrdered)
        {
            var book = GetById(bookId);

            book.ProductsAvailable -= numberOrdered;
        }

        public List<Book> GetByAuthorAndAvailable(string author)
        {
            return this._database.Where(x => x.Author == author && x.ProductsAvailable > 0)
                .ToList();
        }

        public List<Book> GetBooksByProducts(int products)
        {
            return _database.Where(x => x.ProductsAvailable == products)
                .ToList();
        }

        public List<Book> GetBooksByProductsGreaterOrEqual(int products)
        {
            return _database.Where(x => x.ProductsAvailable >= products)
                .ToList();
        }
    }
}
