using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using Validation = System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.Entities
{
    public enum ResidenceHall
    {
        WengatzHall         = 0x00000001,
        BergwallHall        = 0x00000002,
        CampbellHall        = 0x00000003,
        EnglishHall         = 0x00000004,
        FairlaneApartments  = 0x00000005,
        GerigHall           = 0x00000006,
        OlsonHall           = 0x00000007,
        SwallowRobinHall    = 0x00000008,
        WolgemuthHall       = 0x00000009,
        OffCampus           = 0x0000000A,
        MorrisHall          = 0x0000000B,
        BreuningerHall      = 0x0000000C
    }

    [Table(Name = "Exchange.Users")]
    public class User
    {
        #region LINQ to SQL Entities

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [Validation.Required]
        public Int32 UserID { get; set; }

        [Column]
        [Validation.Required(AllowEmptyStrings = false)]
        [Validation.StringLength(32)]
        public String FirstName { get; set; }

        [Column]
        [Validation.Required(AllowEmptyStrings = false)]
        [Validation.StringLength(32)]
        public String LastName { get; set; }

        [Column]
        [Validation.Required(AllowEmptyStrings = false)]
        [Validation.StringLength(64)]
        public String UserName { get; set; }

        [Column]
        [Validation.Required(AllowEmptyStrings = false)]
        [Validation.StringLength(64)]
        public String Email { get; set; }

        [Column]
        public ResidenceHall? ResidenceHall { get; set; }

        [Column]
        [Validation.StringLength(40)]
        public String PasswordHash { get; set; }

        [Column]
        [Validation.StringLength(40)]
        public String ConfirmationHash { get; set; }

        [Column(IsDbGenerated = true)]
        [Validation.Required]
        public DateTime CreationDate { get; set; }

        [Column]
        public DateTime? ActivationDate { get; set; }

        private EntitySet<Listing> listings = new EntitySet<Listing>();

        [Association(Storage = "listings", ThisKey = "UserID", OtherKey = "UserID")]
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

        private EntitySet<Subscription> subscriptions = new EntitySet<Subscription>();
        [Association(Storage = "subscriptions", ThisKey = "UserID", OtherKey = "UserID")]
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

        private EntitySet<Suggestion> suggestions = new EntitySet<Suggestion>();
        [Association(Storage = "suggestions", ThisKey = "UserID", OtherKey = "UserID")]
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

        private EntitySet<Search> searches = new EntitySet<Search>();
        [Association(Storage = "searches", ThisKey = "UserID", OtherKey = "UserID")]
        public EntitySet<Search> Searches
        {
            get
            {
                return searches;
            }
            set
            {
                searches.Assign(value);
            }
        }

        private EntitySet<UserView> userViews = new EntitySet<UserView>();
        [Association(Storage = "userViews", ThisKey = "UserID", OtherKey = "ViewUserID")]
        public EntitySet<UserView> Views
        {
            get
            {
                return userViews;
            }
            set
            {
                userViews.Assign(value);
            }
        }

        #endregion

        public User()
        { }
    }
}