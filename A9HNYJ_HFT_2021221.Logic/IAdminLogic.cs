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
    /// Interface for admin class that includes admin funcionalities.
    /// </summary>
    public interface IAdminLogic : IUserLogic
    {
        Book AddBook(Book book);

        Author AddAuthor(Author aut);

        Publisher AddPublisher(Publisher pub);

        void UpdateBook(Book book);
        void UpdateAuthor(Author au);
        void UpdatePublisher(Publisher pub);


        /// <summary>
        /// Forwards call to repository to delete one boook.
        /// </summary>
        /// <param name="index">Index of the item to remove.</param>
        public void DeleteBook(int index);

        /// <summary>
        /// Forwards call to repository to delete one Publisher.
        /// </summary>
        /// <param name="index"> Index of the item to remove.</param>
        public void DeletePublisher(int index);

        /// <summary>
        /// Forwards call to repository to delete one author.
        /// </summary>
        /// <param name="index"> Index of the item to remove.</param>
        public void DeleteAuthor(int index);
    }
}
