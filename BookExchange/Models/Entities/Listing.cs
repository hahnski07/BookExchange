using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using Validation = System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.Entities
{
    public enum TransferMethod
    {
        Buy             = 0x00000001,
        BuyRent         = 0x00000002,
        Rent            = 0x00000003
    }

    public enum BookCondition
    {
        New             = 0x00000001,
        LikeNew         = 0x00000002,
        VeryGood        = 0x00000003,
        Good            = 0x00000004,
        Acceptable      = 0x00000005,
        Unacceptable    = 0x00000006
    }

    [Table(Name = "Exchange.Listings")]
    public class Listing
    {
        #region LINQ to SQL

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [Validation.Required]
        public Int32 ListingID { get; set; }

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

        [Column]
        [Validation.Required]
        public TransferMethod TransferMethod { get; set; }

        [Column]
        [Validation.Required]
        public BookCondition BookCondition { get; set; }

        [Column(IsDbGenerated = true)]
        [Validation.Required]
        public DateTime CreationDate { get; set; }

        [Column]
        public DateTime? RemovalDate { get; set; }

        #endregion

        public Listing()
        { }
    }
}