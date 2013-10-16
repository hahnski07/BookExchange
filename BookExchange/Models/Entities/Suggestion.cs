using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using Validation = System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.Entities
{
    [Table(Name = "Exchange.Suggestions")]
    public class Suggestion
    {
        #region LINQ to SQL

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [Validation.Required]
        public Int32 SuggestionID { get; set; }

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
        public Int32 SubjectID { get; set; }

        private EntityRef<Subject> subject = new EntityRef<Subject>();
        [Association(Storage = "subject", ThisKey = "SubjectID", OtherKey = "SubjectID", IsForeignKey = true)]
        public Subject Subject
        {
            get
            {
                return subject.Entity;
            }
            set
            {
                subject.Entity = value;
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

        #endregion

        public Suggestion()
        { }
    }
}