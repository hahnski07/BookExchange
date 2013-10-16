using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookExchange.Models.Repository
{
    public class MemoryRepository<T> : IRepository<T>
        where T : class
    {
        private List<T> data;

        public MemoryRepository()
        {
            data = new List<T>();
        }

        public IQueryable<T> Data
        {
            get
            {
                return data.AsQueryable();
            }
        }

        public void Insert(T dataObject)
        {
            data.Add(dataObject);
        }

        public void Delete(T dataObject)
        {
            data.Remove(dataObject);
        }

        public void Save()
        {

        }
    }
}