using DotNet.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.Analyzares
{
    public abstract class BaseAnalyzator
    {
        protected BookRepository _bookRepository;

        public BaseAnalyzator(BookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }
    }
}
