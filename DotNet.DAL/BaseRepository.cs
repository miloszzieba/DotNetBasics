using DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.DAL
{
    public abstract class BaseRepository<T> where T : IModel
    {
        protected List<T> _database = new List<T>();
        private int counter;

        public void Insert(T element)
        {
            element.Id = ++counter;

            _database.Add(element);
        }

        public void Remove(T element)
        {
            _database.Remove(element);
        }

        public void RemoveById(int id)
        {
            this._database.RemoveAll(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return _database;
        }

        public virtual T GetById(int id)
        {
            return this._database.SingleOrDefault(x => x.Id == id);
        }
    }
}
