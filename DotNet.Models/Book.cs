using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Models
{
    public class Book : BaseModel, IModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }

        public int ProductsAvailable { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string author, int publicationYear, string isbn, int productsAvailable, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.PublicationYear = publicationYear;
            this.ProductsAvailable = productsAvailable;
            this.Price = price;
        }

        public override string ToString()
        {
            return "Title:" + this.Title + ", Author: " + this.Author;
        }
    }
}
