using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using Validation = System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.Entities
{
    [Table(Name = "Exchange.Thumbnails")]
    public class Thumbnail
    {
        #region LINQ to SQL

        [Column(IsPrimaryKey = true)]
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
        public Int32 Width { get; set; }

        [Column]
        [Validation.Required]
        public Int32 Height { get; set; }

        [Column]
        [Validation.Required]
        public String ContentType { get; set; }

        [Column]
        [Validation.Required]
        public Byte[] ThumbnailBinary { get; set; }

        public Thumbnail()
        {

        }

        #endregion
    }
}