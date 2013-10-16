using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data.Linq.Mapping;

using BookExchange.Models.Entities;

namespace BookExchange.Models.Repository
{
    [Database(Name = "ExchangeServer")]
    public class BookExchangeDataContext : DataContext
    {
        public Table<Author> Authors;
        public Table<Listing> Listings;
        public Table<Search> Searchs;
        public Table<Subject> Subjects;
        public Table<Subscription> Subscriptions;
        public Table<Suggestion> Suggestions;
        public Table<TextBook> TextBooks;
        public Table<Thumbnail> Thumbnails;
        public Table<User> Users;
        public Table<View> Views;

        public BookExchangeDataContext()
            : base(System.Configuration.ConfigurationManager.ConnectionStrings["BookExchange"].ConnectionString)
        { }
    }
}