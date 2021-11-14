using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Data;

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

        /// <summary>
        /// Adds new book item to the table.
        /// </summary>
        /// <param name="author"> Author id.</param>
        /// <param name="publisher"> Publisher id.</param>
        /// <param name="bookname"> Book title.</param>
        /// <param name="price"> Book price. </param>
        /// <param name="supply"> Book supply. </param>
        /// <param name="year"> Year of release. </param>
        /// <returns> New book item or null. </returns>
        public Book AddBook(int author, int publisher, string bookname, int price, int supply, int year);
    }
}
