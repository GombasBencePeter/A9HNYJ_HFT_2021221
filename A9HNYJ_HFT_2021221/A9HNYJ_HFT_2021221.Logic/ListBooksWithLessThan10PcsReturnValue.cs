using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Models;


namespace A9HNYJ_HFT_2021221.Logic
{
    /// <summary>
    /// Query return class, contains the title of the book, the name of the publisher, the supply currently present and the number of days it takes to deliver.
    /// </summary>
    public class ListBooksWithLessThan10PcsReturnValue
    {
        /// <summary>
        /// Gets or Sets the title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets the name of the publisher.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or Sets the number of copies in supply.
        /// </summary>
        public int Supply { get; set; }

        /// <summary>
        /// Gets or Sets the number of days new supply can be delivered from publisher.
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// Override for comparison to other objects.
        /// </summary>
        /// <param name="obj"> The object to compare with.</param>
        /// <returns> True if the object obj is the same with this instance.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ListBooksWithLessThan10PcsReturnValue)
            {
                ListBooksWithLessThan10PcsReturnValue comp = (ListBooksWithLessThan10PcsReturnValue)obj;
                return this.Title == comp.Title && this.Publisher == comp.Publisher && this.Supply == comp.Supply && this.Days == comp.Days;
            }

            return false;
        }

        /// <summary>
        /// Override for hasjcode generation.
        /// </summary>
        /// <returns> Hashcode of the instance.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
