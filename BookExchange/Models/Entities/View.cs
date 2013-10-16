using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using Validation = System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.Entities
{
    public enum ViewCategory
    {
        TextBook    = 0x00000001,
        User        = 0x00000002
    }

    [Table(Name = "History.Views")]
    [InheritanceMapping(Code = ViewCategory.TextBook, Type = typeof(TextBookView), IsDefault = true)]
    [InheritanceMapping(Code = ViewCategory.User, Type = typeof(UserView))]
    public class View
    {
        #region LINQ to SQL Entities

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [Validation.Required]
        public Int32 ViewID { get; set; }

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

        [Column(IsDiscriminator = true)]
        [Validation.Required]
        public ViewCategory ViewCategory { get; set; }

        [Column(IsDbGenerated = true)]
        [Validation.Required]
        public DateTime CreationDate { get; set; }

        #endregion
    }

    public class TextBookView : View
    {
        #region LINQ to SQL Entities

        [Column]
        [Validation.Required]
        public Int32 ViewTextBookID { get; set; }

        private EntityRef<TextBook> viewTextBook = new EntityRef<TextBook>();

        [Association(Storage = "viewTextBook", ThisKey = "ViewTextBookID", OtherKey = "TextBookID", IsForeignKey = true)]
        public TextBook ViewTextBook
        {
            get
            {
                return viewTextBook.Entity;
            }
            set
            {
                viewTextBook.Entity = value;
            }
        }

        #endregion
    }

    public class UserView : View
    {
        #region LINQ to SQL Entities

        [Column]
        [Validation.Required]
        public Int32 ViewUserID { get; set; }

        private EntityRef<User> viewUser = new EntityRef<User>();

        [Association(Storage = "viewUser", ThisKey = "ViewUserID", OtherKey = "UserID", IsForeignKey = true)]
        public User ViewUser
        {
            get
            {
                return viewUser.Entity;
            }
            set
            {
                viewUser.Entity = value;
            }
        }

        #endregion
    }
}