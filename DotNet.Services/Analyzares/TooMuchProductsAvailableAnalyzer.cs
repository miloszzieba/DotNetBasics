using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.DAL;
using DotNet.Models;
using DotNet.Models.Exceptions;
using DotNet.Models.Warning;

namespace DotNet.Services.Analyzares
{
    public class TooMuchProductsAvailableAnalyzer : BaseAnalyzator, IAnalyzator
    {
        public TooMuchProductsAvailableAnalyzer(BookRepository bookRepository)
            : base(bookRepository)
        {
        }

        public List<BookWarning> Analyze()
        {
            var warningList = new List<BookWarning>();

            var tooMuchBooks = _bookRepository.GetBooksByProductsGreaterOrEqual(50);
            if (!tooMuchBooks.Any())
                throw new AnalyzerDataException("Lista jest pusta");

            foreach (var book in tooMuchBooks)
            {
                warningList.Add(new BookWarning()
                {
                    Message = "Jest więcej niż 50 produktów na stanie",
                    Book = book
                });
            }

            return warningList;
        }
    }
}
