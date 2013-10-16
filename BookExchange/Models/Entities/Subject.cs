using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using Validation = System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.Entities
{
    [Table(Name = "Exchange.Subjects")]
    public class Subject
    {
        #region LINQ to SQL

        [Column(IsPrimaryKey = true)]
        [Validation.Required]
        public Int32 SubjectID { get; set; }

        [Column]
        [Validation.Required(AllowEmptyStrings = false)]
        [Validation.StringLength(32)]
        public String Name { get; set; }

        [Column]
        [Validation.Required(AllowEmptyStrings = false)]
        [Validation.StringLength(3, MinimumLength = 3)]
        public String Abbreviation { get; set; }

        private EntitySet<Suggestion> suggestions = new EntitySet<Suggestion>();

        [Association(Storage = "suggestions", ThisKey = "SubjectID", OtherKey = "SubjectID")]
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

        #endregion

        public String NameWithAbbreviation
        {
            get
            {
                return String.Format("{0} {{{1}}}", this.Name, this.Abbreviation);
            }
        }

        public Subject()
        { }
    }
}