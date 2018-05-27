using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.DAL;
using DotNet.Models;
using DotNet.Models.Exceptions;
using DotNet.Models.Warning;
using DotNet.Tools;

namespace DotNet.Services.Analyzares
{
    public class ZeroProductsAvailaibleAnalyzator : IAnalyzator
    {
        private BookRepository _bookRepository;

        public ZeroProductsAvailaibleAnalyzator(BookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public List<BookWarning> Analyze()
        {
            var warningList = new List<BookWarning>();

            var zeroBooks = _bookRepository.GetBooksByProducts(0);
            if (zeroBooks.IsNullOrEmpty())
                throw new AnalyzerDataException("Lista jest pusta");

            foreach (var book in zeroBooks)
            {
                warningList.Add(new BookWarning()
                {
                    Message = "Brakuje produktów na stanie",
                    Book = book
                });
            }

            return warningList;
        }
    }
}
