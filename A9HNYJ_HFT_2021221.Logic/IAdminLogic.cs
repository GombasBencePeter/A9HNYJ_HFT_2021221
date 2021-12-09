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
        /// Forwards call to repository to change author name.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="newName"> Name to change item name into.</param>
        public void ChangeAuthorName(int index, string newName);

        /// <summary>
        /// Forwards call to repository to change if author is forkids.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="forKids"> Bool value to change author forKids value into.</param>
        public void ChangeForKidsAuthor(int index, bool forKids);

        /// <summary>
        /// Forwards call to repository to change if author is stil active.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="isActive"> Bool value to change author isActive into.</param>
        public void ChangeIsActiveAuthor(int index, bool isActive);

        /// <summary>
        /// Forwards call to repository to change name for publisher.
        /// </summary>
        /// <param name="index">Index of the item to modify.</param>
        /// <param name="name"> New name value.</param>
        public void ChangePublisherName(int index, string name);

        /// <summary>
        /// Forwards call to repository to change website for publisher.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="website"> New website value.</param>
        public void ChangeWebsite(int index, string website);

        /// <summary>
        /// Forwards call to repository to change language for publisher.
        /// </summary>
        /// <param name="index">Index of the item to modify.</param>
        /// <param name="language"> New language value.</param>
        public void ChangePublisherLanguage(int index, string language);

        /// <summary>
        /// Forwards call to repository to change if publisher is still active.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="isactive"> Bool value to change publisher isActive into.</param>
        public void ChangePublisherIsActive(int index, bool isactive);

        /// <summary>
        /// Forwards call to repository to change delivery days for publisher.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="days"> Number of days to change deliverydays into.</param>
        public void ChangeDeliveryDays(int index, int days);

        /// <summary>
        /// Forwards call to repository to change book name.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="newName">Name to change item name into.</param>
        public void ChangeBookName(int index, string newName);

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
