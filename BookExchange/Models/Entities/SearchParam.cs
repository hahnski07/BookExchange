using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using Validation = System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.Entities
{
    public enum TextBookParamCategory
    {
        ISBN            = 0x00000001,
        Title           = 0x00000002,
        Author          = 0x00000003,
        Publisher       = 0x00000004,
        YearMin         = 0x00000005,
        YearMax         = 0x00000006,
        Subject         = 0x00000007,
        Sort            = 0x00000008,
        Direction       = 0x00000009
    }

    public enum UserParamCategory
    {
        Name            = 0x00000001,
        Residence       = 0x00000002,
        Sort            = 0x00000003,
        Direction       = 0x00000004
    }

    [Table(Name = "History.SearchParams")]
    public class TextBookSearchParam
    {
        #region LINQ to SQL Entities

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [Validation.Required]
        public Int32 SearchParamID { get; set; }

        [Column]
        [Validation.Required]
        public Int32 SearchID { get; set; }

        [Column]
        [Validation.Required(AllowEmptyStrings = false)]
        [Validation.StringLength(64)]
        public String ParamValue { get; set; }

        private EntityRef<TextBookSearch> textBookSearch = new EntityRef<TextBookSearch>();

        [Association(Storage = "textBookSearch", ThisKey = "SearchID", OtherKey = "SearchID", IsForeignKey = true)]
        public TextBookSearch Search
        {
            get
            {
                return textBookSearch.Entity;
            }
            set
            {
                TextBookSearch priorSearch = textBookSearch.Entity;
                TextBookSearch newSearch = value;

                if (newSearch != priorSearch)
                {
                    // Remove this Search Param from our prior
                    textBookSearch.Entity = null;
                    if (priorSearch != null)
                    {
                        priorSearch.SearchParams.Remove(this);
                    }

                    textBookSearch.Entity = newSearch;

                    // Add to new list of params
                    if (newSearch != null)
                    {
                        newSearch.SearchParams.Add(this);
                    }
                }

                textBookSearch.Entity = value;
            }
        }

        [Column]
        [Validation.Required]
        public TextBookParamCategory ParamCategory { get; set; }

        #endregion

        public TextBookSearchParam()
        {

        }
    }

    [Table(Name = "History.SearchParams")]
    public class UserSearchParam
    {
        #region LINQ to SQL Entities

        private EntityRef<UserSearch> userSearch = new EntityRef<UserSearch>();

        [Association(Storage = "userSearch", ThisKey = "SearchID", OtherKey = "SearchID", IsForeignKey = true)]
        public UserSearch Search
        {
            get
            {
                return userSearch.Entity;
            }
            set
            {
                userSearch.Entity = value;
            }
        }

        [Column]
        [Validation.Required]
        public UserParamCategory ParamCategory { get; set; }

        #endregion

        public UserSearchParam()
            : base()
        {

        }
    }
}