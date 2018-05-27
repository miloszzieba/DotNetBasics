using DotNet.DAL;
using DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly BookRepository _bookRepository;

        public OrderService(OrderRepository orderRepository, BookRepository bookRepository)
        {
            this._orderRepository = orderRepository;
            this._bookRepository = bookRepository;
        }

        public void PlaceOrder(Order order)
        {
            foreach (var bookOrdered in order.BooksOrderedList)
            {
                var book = _bookRepository.GetById(bookOrdered.BookId);
                if (book.ProductsAvailable < bookOrdered.NumberOrdered)
                    //TO DO: Dodać informację, jakiej książki i w jakiej ilości np. napisać własny wyjątek
                    throw new ApplicationException("Brakuje książek w magazynie");
            }

            foreach (var bookOrdered in order.BooksOrderedList)
            {
                var book = _bookRepository.GetById(bookOrdered.BookId);

                _bookRepository.DecreaseProductsAvailable(bookOrdered.BookId, bookOrdered.NumberOrdered);
            }

            _orderRepository.Insert(order);
        }
    }
}
