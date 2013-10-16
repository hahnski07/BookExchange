using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookExchange.Models.Repository
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> Data { get; }
        void Insert(T dataObject);
        void Delete(T dataObject);
        void Save();
    }
}