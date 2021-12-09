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
    /// Interface for implementig classes to handle "Book" table.
    /// </summary>
    public interface IBookRepository : IRepository<Book>
    {
        /// <summary>
        /// Changes Book name and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newName"> New name. </param>
        void ChangeBookName(int index, string newName);

        void Update(Book book);

        /// <summary>
        /// Changes Book price and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newPrice"> New price.</param>
        void ChangePrice(int index, int newPrice);

        /// <summary>
        /// Changes book supply and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="changeVal"> New Supply. </param>
        void ChangeSupply(int index, int changeVal);

    }
}
