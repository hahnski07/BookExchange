using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using Validation = System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.Entities
{
    public enum SearchCategory
    {
        Default         = 0x00000000,
        TextBook        = 0x00000001,
        User            = 0x00000002
    }

    [Table(Name = "History.Searches")]
    [InheritanceMapping(Code = SearchCategory.Default, Type = typeof(DefaultSearch), IsDefault = true)]
    [InheritanceMapping(Code = SearchCategory.TextBook, Type = typeof(TextBookSearch))]
    [InheritanceMapping(Code = SearchCategory.User, Type = typeof(UserSearch))]
    public class Search
    {
        #region LINQ to SQL Entities

        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public Int32 SearchID { get; set; }

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
        public SearchCategory SearchCategory { get; set; }

        [Column]
        [Validation.Required]
        [Validation.Range(0, Int32.MaxValue)]
        public Int32 ResultCount { get; set; }

        [Column]
        [Validation.Required]
        [Validation.Range(0.0, Double.MaxValue)]
        public Double QueryDuration { get; set; }

        [Column(IsDbGenerated = true)]
        public DateTime CreationDate { get; set; }

        #endregion
    }

    public class DefaultSearch : Search
    {

    }

    public class TextBookSearch : Search
    {
        public TextBookSearch()
            : base()
        { }

        private EntitySet<TextBookSearchParam> textBookSearchParams = new EntitySet<TextBookSearchParam>();

        [Association(Storage = "textBookSearchParams", ThisKey = "SearchID", OtherKey = "SearchID")]
        public EntitySet<TextBookSearchParam> SearchParams
        {
            get
            {
                return textBookSearchParams;
            }
            set
            {
                textBookSearchParams.Assign(value);
            }
        }

        public void AddParam(TextBookParamCategory category, String paramValue)
        {
            this.SearchParams.Add(new TextBookSearchParam()
            {
                ParamCategory = category,
                ParamValue = paramValue,
                Search = this
            });
        }
    }

    public class UserSearch : Search
    {
        public UserSearch()
            : base()
        { }

        private EntitySet<UserSearchParam> userSearchParams = new EntitySet<UserSearchParam>();
        [Association(Storage = "userSearchParams", ThisKey = "SearchID", OtherKey = "SearchID")]
        public EntitySet<UserSearchParam> SearchParams
        {
            get
            {
                return userSearchParams;
            }
            set
            {
                userSearchParams.Assign(value);
            }
        }
    }
}