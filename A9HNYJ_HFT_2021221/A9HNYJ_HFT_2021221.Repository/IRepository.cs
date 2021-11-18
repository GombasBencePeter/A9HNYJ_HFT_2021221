using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Data;
using A9HNYJ_HFT_2021221.Models;


namespace A9HNYJ_HFT_2021221.Repository
{
    /// <summary>
    /// Generic interface for common repository functions.
    /// </summary>
    /// <typeparam name="T"> Book, Publisher or Author.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Get one item from the table by index.
        /// </summary>
        /// <param name="index"> Index of item to get.</param>
        /// <returns> T item.</returns>
        T GetOne(int index);

        /// <summary>
        /// Gets all items from the corresponding table.
        /// </summary>
        /// <returns> Collection of items.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Deletes one item form the table.
        /// </summary>
        /// <param name="index"> Index of the item to delete.</param>
        void DeleteOne(int index);
    }
}
