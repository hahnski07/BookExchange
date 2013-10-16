using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using Validation = System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.Entities
{
    [Table(Name = "Exchange.Subscriptions")]
    public class Subscription
    {
        #region LINQ to SQL

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [Validation.Required]
        public Int32 SubscriptionID { get; set; }

        [Column]
        [Validation.Required]
        public Int32 TextBookID { get; set; }

        private EntityRef<TextBook> textBook = new EntityRef<TextBook>();

        [Association(Storage = "textBook", ThisKey = "TextBookID", OtherKey = "TextBookID", IsForeignKey = true)]
        public TextBook TextBook
        {
            get
            {
                return textBook.Entity;
            }
            set
            {
                textBook.Entity = value;
            }
        }

        [Column]
        [Validation.Required]
        public Int32 UserID { get; set; }

        private EntityRef<User> user = new EntityRef<User>();

        [Association(Storage = "user", ThisKey = "UserID", OtherKey = "UserID", IsForeignKey = true)]
        public User User
        {
            get
            {
                return user.Entity;
            }
            set
            {
                user.Entity = value;
            }
        }

        [Column(IsDbGenerated = true)]
        [Validation.Required]
        public DateTime CreationDate { get; set; }

        [Column]
        public DateTime? RemovalDate { get; set; }

        #endregion

        public Subscription()
        { }
    }
}