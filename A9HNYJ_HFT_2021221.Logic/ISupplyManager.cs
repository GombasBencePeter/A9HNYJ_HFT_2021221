using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Data;
using A9HNYJ_HFT_2021221.Repository;
using A9HNYJ_HFT_2021221.Models;


namespace A9HNYJ_HFT_2021221.Logic
{
    /// <summary>
    /// Interface for SupplyManager class that includes supply manager funcionalities.
    /// </summary>
    public interface ISupplyManager
    {
        /// <summary>
        /// FOrwards call to repository to change the price of one book.
        /// </summary>
        /// <param name="index"> Index of the item to modify. </param>
        /// <param name="newprice"> New price of the book (only positive number). </param>
        public void ChangePrice(int index, int newprice);

        /// <summary>
        /// Forwards call to repository to change the current supply of one book.
        /// </summary>
        /// <param name="index"> Index of the item to modify. </param>
        /// <param name="newSupply"> New supply of that book (only positive number). </param>
        public void ChangeSupply(int index, int newSupply);

        /// <summary>
        /// Forwards call to repository to add to the current supply of one book. Checks if new amount is positive. If not nothing happens.
        /// </summary>
        /// <param name="index"> Index of the item to modify. </param>
        /// <param name="valToAdd"> Amount to add. </param>
        public void AddSupply(int index, int valToAdd);
    }
}
