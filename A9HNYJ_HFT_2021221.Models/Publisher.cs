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
    /// Entity class Publisher.
    /// </summary>
    [Table("Publisher")]
    public class Publisher
    {
        /// <summary>
        /// Gets or sets publisher primary key, auto increment.
        /// </summary>
        [Key]
        public int PublisherID { get; set; }

        /// <summary>
        /// Gets or sets publisher name.
        /// </summary>
        public string PublisherName { get; set; }

        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets publisher language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets publisher webpage link.
        /// </summary>
        public string Webpage { get; set; }

        /// <summary>
        /// Gets or sets how many days it takes for the publisher to deliver books.
        /// </summary>
        public int DelivareDays { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is the publisher still active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Override of ToStringArray.
        /// </summary>
        /// <returns> String patched together from the values. </returns>
        public override string ToString()
        {
            return "ID: "+this.PublisherID.ToString() + " || Name: " + this.PublisherName + " || Language: " + this.Language + " || WebPage: " + this.Webpage + " || Days of delivery " + this.DelivareDays.ToString() + " || IsActive: " + this.IsActive.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj is Publisher)
            {
                Publisher c = obj as Publisher;
                return this.PublisherID == c.PublisherID && this.PublisherName == c.PublisherName && this.Language == c.Language && this.IsActive == c.IsActive && this.DelivareDays == c.DelivareDays && this.Webpage == c.Webpage;
            }
            return false;

        }
    }
}
