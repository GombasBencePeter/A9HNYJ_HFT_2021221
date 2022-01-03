using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9HNYJ_HFT_2021221.Models
{
    /// <summary>
    /// Entity class Author.
    /// </summary>
    [Table("Author")]
    public class Author
    {
        /// <summary>
        /// Gets or sets author primary key, auto increment.
        /// </summary>
        [Key]
        public int AuthorKey { get; set; }

        /// <summary>
        /// Gets or sets author name.
        /// </summary>
        public string AuthorName { get; set; }

        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets born year of author.
        /// </summary>
        public int YearBorn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is the author still active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets original language of the author.
        /// </summary>
        public string OriginalLanguage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the author wrote kid friendly books.
        /// </summary>
        public bool ForKids { get; set; }

        /// <summary>
        /// Override Tostring.
        /// </summary>
        /// <returns> String patched together from the values.</returns>
        public override string ToString()
        {
            return "Id: "+this.AuthorKey.ToString() + " || Name: " + this.AuthorName + " || Year of birth: " + this.YearBorn.ToString() + " || IsActive: " + this.IsActive.ToString() + " || Language: " + this.OriginalLanguage + " || ForKids: " + this.ForKids.ToString();
        }

        public override bool Equals(object o)
        {
            if(o is Author)
            {
                Author c = o as Author;
                return this.AuthorKey == c.AuthorKey && this.AuthorName == c.AuthorName && this.ForKids == c.ForKids && this.IsActive == c.IsActive && this.OriginalLanguage == c.OriginalLanguage && this.YearBorn == c.YearBorn;
            }
            return false;
        }
    }
}
