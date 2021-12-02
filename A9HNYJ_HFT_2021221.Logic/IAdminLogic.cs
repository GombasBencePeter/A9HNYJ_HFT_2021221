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
        /// <summary>
        /// Checks if given names for Author and Publishers are ok. If not, returns null. If ok, forwards values for repository.
        /// </summary>
        /// <param name="authorname"> Name of Author. </param>
        /// <param name="publishername"> Name of Publisher. </param>
        /// <param name="bookname">Name of new book. </param>
        /// <param name="price"> Proce of book. </param>
        /// <param name="supply"> Supply of new book.</param>
        /// <param name="year"> The year the book was published. </param>
        /// <returns> The new Book if creation successful, null if not.</returns>
        public Book AddBook(string authorname, string publishername, string bookname, int price, int supply, int year);

        public Book AddBook(Book book);

        public void UpdateBook(Book book);
        public void UpdateAuthor(Author au);
        public void UpdatePublisher(Publisher pub);

        /// <summary>
        /// Forwards values to repository, to create new publisher item.
        /// </summary>
        /// <param name="publishername"> Name for new Publisher. </param>
        /// <param name="language"> Language for new publisher. </param>
        /// <param name="webpage"> Webpage of new publisher. </param>
        /// <param name="deliverydays">Delivery days number for new publisher. </param>
        /// <param name="isactive"> Isactive for new publisher. </param>
        /// <returns> New publisher item or null if not successful.</returns>
        public Publisher AddPublisher(string publishername, string language, string webpage, int deliverydays, bool isactive);

        /// <summary>
        /// Forwards values to repository to create new Author item.
        /// </summary>
        /// <param name="authorname"> authroname for new author. </param>
        /// <param name="yearborn"> yearborn for new author. </param>
        /// <param name="isactive"> isactive for new author. </param>
        /// <param name="originallanguage"> originallanguage for new author. </param>
        /// <param name="forkids"> forkids for new author. </param>
        /// <returns> The Author item created. Null if not successful. </returns>
        public Author AddAuthor(string authorname, int yearborn, bool isactive, string originallanguage, bool forkids);

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
