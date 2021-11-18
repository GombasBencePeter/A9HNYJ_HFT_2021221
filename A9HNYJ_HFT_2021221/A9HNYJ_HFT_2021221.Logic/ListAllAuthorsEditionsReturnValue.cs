using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Models;


namespace A9HNYJ_HFT_2021221.Logic
{
    /// <summary>
    /// Query return class, contains the name of the author and the number of languages the have publications in.
    /// </summary>
    public class ListAllAuthorsEditionsReturnValue
    {
        /// <summary>
        /// Gets or Sets name of author.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets number of languages they have publications.
        /// </summary>
        public int Editions { get; set; }

        /// <summary>
        /// Override for comparison to other objects.
        /// </summary>
        /// <param name="obj"> The object to compare with.</param>
        /// <returns> True if the object obj is the same with this instance.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ListAllAuthorsEditionsReturnValue)
            {
                ListAllAuthorsEditionsReturnValue comp = (ListAllAuthorsEditionsReturnValue)obj;
                return this.Name == comp.Name && this.Editions == comp.Editions;
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
