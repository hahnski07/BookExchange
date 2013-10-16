using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using Validation = System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.Entities
{
    [Table(Name = "Exchange.TextBooks")]
    public class TextBook
    {
        #region LINQ to SQL Entities

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [Validation.Required]
        public Int32 TextBookID { get; set; }

        [Column]
        [Validation.Required(AllowEmptyStrings = false)]
        [Validation.StringLength(13, MinimumLength = 13)]
        public String ISBN13 { get; set; }

        [Column]
        [Validation.Required(AllowEmptyStrings = false)]
        [Validation.StringLength(256)]
        public String Title { get; set; }

        [Column]
        [Validation.StringLength(256)]
        public String Subtitle { get; set; }

        [Column]
        public String Description { get; set; }

        [Column]
        [Validation.StringLength(256)]
        public String Publisher { get; set; }

        [Column]
        public DateTime? PublishDate { get; set; }

        [Column]
        public Int32? PageCount { get; set; }

        [Column(IsDbGenerated = true)]
        public DateTime CreationDate { get; set; }

        private EntityRef<Thumbnail> thumbnail = new EntityRef<Thumbnail>();
        [Association(Storage = "thumbnail", ThisKey = "TextBookID", OtherKey = "TextBookID")]
        public Thumbnail Thumbnail
        {
            get
            {
                return thumbnail.Entity;
            }
            set
            {
                thumbnail.Entity = value;
            }
        }

        private EntitySet<Listing> listings = new EntitySet<Listing>();
        [Association(Storage = "listings", ThisKey = "TextBookID", OtherKey = "TextBookID")]
        public EntitySet<Listing> Listings
        {
            get
            {
                return listings;
            }
            set
            {
                listings.Assign(value);
            }
        }

        private EntitySet<Suggestion> suggestions = new EntitySet<Suggestion>();
        [Association(Storage = "suggestions", ThisKey = "TextBookID", OtherKey = "TextBookID")]
        public EntitySet<Suggestion> Suggestions
        {
            get
            {
                return suggestions;
            }
            set
            {
                suggestions.Assign(value);
            }
        }

        private EntitySet<Author> authors = new EntitySet<Author>();
        [Association(Storage = "authors", ThisKey = "TextBookID", OtherKey = "TextBookID")]
        public EntitySet<Author> Authors
        {
            get
            {
                return authors;
            }
            set
            {
                authors.Assign(value);
            }
        }

        private EntitySet<Subscription> subscriptions = new EntitySet<Subscription>();
        [Association(Storage = "subscriptions", ThisKey = "TextBookID", OtherKey = "TextBookID")]
        public EntitySet<Subscription> Subscriptions
        {
            get
            {
                return subscriptions;
            }
            set
            {
                subscriptions.Assign(value);
            }
        }

        //private EntitySet<TextBookSearch> textBookSearches = new EntitySet<TextBookSearch>();
        //[Association(Storage = "textBookSearches", ThisKey = "TextBookID", OtherKey = "TextBookID")]
        //public EntitySet<TextBookSearch> Searches
        //{
        //    get
        //    {
        //        return textBookSearches;
        //    }
        //    set
        //    {
        //        textBookSearches.Assign(value);
        //    }
        //}

        private EntitySet<TextBookView> textBookViews = new EntitySet<TextBookView>();
        [Association(Storage = "textBookViews", ThisKey = "TextBookID", OtherKey = "ViewTextBookID")]
        public EntitySet<TextBookView> Views
        {
            get
            {
                return textBookViews;
            }
            set
            {
                textBookViews.Assign(value);
            }
        }


        #endregion

        public TextBook()
        { }
    }
}