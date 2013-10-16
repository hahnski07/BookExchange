using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using Validation = System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.Entities
{
    [Table(Name = "Exchange.Authors")]
    public class Author
    {
        #region LINQ to SQL

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [Validation.Required]
        public Int32 AuthorID { get; set; }

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
        [Validation.Required(AllowEmptyStrings = false)]
        [Validation.StringLength(64)]
        public String Name { get; set; }

        #endregion

        public Author()
        { }
    }
}