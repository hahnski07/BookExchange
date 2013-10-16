using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.IO;

namespace BookExchange.Models.Repository
{
    public class DatabaseRepository<T> : IRepository<T>
        where T : class
    {
        private BookExchangeDataContext dataContext;
        private Table<T> dataTable;

        public DatabaseRepository()
        {
            dataContext = new BookExchangeDataContext();

            // Find the field of the appropiate type in the dataContext that we will execute against
            dataTable = (Table<T>)typeof(BookExchangeDataContext).GetFields().Where(f => f.FieldType == typeof(Table<T>)).Single().GetValue(dataContext);
        }

        ~DatabaseRepository()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        }

        public IQueryable<T> Data
        {
            get
            {
                return dataTable.AsQueryable();
            }
        }

        public void Insert(T dataObject)
        {
            dataTable.InsertOnSubmit(dataObject);
        }

        public void Delete(T dataObject)
        {
            dataTable.DeleteOnSubmit(dataObject);
        }

        public void Save()
        {
            dataContext.SubmitChanges();
        }
    }
}