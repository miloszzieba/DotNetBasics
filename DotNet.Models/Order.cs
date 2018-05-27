using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Models
{
    public class Order : BaseModel, IModel
    {
        public DateTime Date { get; set; }
        public List<BookOrdered> BooksOrderedList { get; set; }

        public Order()
        {
            this.Date = DateTime.Now;
            this.BooksOrderedList = new List<BookOrdered>();
        }
    }
}
