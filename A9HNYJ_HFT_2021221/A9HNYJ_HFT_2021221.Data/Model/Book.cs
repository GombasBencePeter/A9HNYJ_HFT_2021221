using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9HNYJ_HFT_2021221.Data
{
    /// <summary>
    /// Entity class Book.
    /// </summary>
    [Table("Book")]
    public class Book
    {
        /// <summary>
        /// Gets or sets the primary key, auto increment.
        /// </summary>
        [Key]
        public int BookID { get; set; }

        /// <summary>
        /// Gets or sets foreign key for an Author entity.
        /// </summary>
        [ForeignKey("Author")]
        public int AuthorID { get; set; }

        /// <summary>
        /// Gets or sets foreign key for an Publisher entity.
        /// </summary>
        [ForeignKey("Publisher")]
        public int PublisherID { get; set; }

        /// <summary>
        /// Gets or sets title of the book.
        /// </summary>
        public string Bookname { get; set; }

        /// <summary>
        /// Gets or sets price of the book.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets current supply of the book.
        /// </summary>
        public int Supply { get; set; }

        /// <summary>
        /// Gets or sets the year of release.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// ToString with array return.
        /// </summary>
        /// <returns> Returns String array containg all values. Not the best implementation, might change it later. </returns>
        public new string[] ToString()
        {
            return new string[7] { this.BookID.ToString(), this.AuthorID.ToString(), this.PublisherID.ToString(), this.Bookname, this.Price.ToString(), this.Supply.ToString(), this.Year.ToString() };
        }

        /// <summary>
        /// Override of Equals for comparison.
        /// </summary>
        /// <param name="obj"> Object to compre with.</param>
        /// <returns> True if they are equal, false if not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Book)
            {
                Book comp = (Book)obj;
                return this.BookID == comp.BookID && this.AuthorID == comp.AuthorID && this.PublisherID == comp.PublisherID
                    && this.Price == comp.Price && this.Supply == comp.Supply && this.Year == comp.Year && this.Bookname == comp.Bookname;
            }

            return false;
        }

        /// <summary>
        /// Override of GetHashCOde for comparison.
        /// </summary>
        /// <returns> Usual GetHashCode().</returns>
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
