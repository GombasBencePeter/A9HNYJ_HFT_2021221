using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Repository;
using A9HNYJ_HFT_2021221.Models;

namespace A9HNYJ_HFT_2021221.Logic
{
    /// <summary>
    /// Logic class for admin functions. Inherits user functions from UserLogic class.
    /// </summary>
    public class AdminLogic : UserLogic, IAdminLogic
    {
        private IBookRepository bookRepo;
        private IPublisherRepository pubRepo;
        private IAuthorRepository autRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminLogic"/> class.
        /// Constructor for AdminLogic class.
        /// </summary>
        /// <param name="br"> IBookRepository implementing class. </param>
        /// <param name="pr"> IPublisherRepository implementing class. </param>
        /// <param name="ar"> IAuthorRepository implementing class. </param>
        public AdminLogic(IBookRepository br, IPublisherRepository pr, IAuthorRepository ar)
            : base(br, pr, ar)
        {
            this.bookRepo = br;
            this.pubRepo = pr;
            this.autRepo = ar;
        }

        public Author AddAuthor(Author aut)
        {
            return autRepo.AddItem(aut);
        }

        public Book AddBook(Book item)
        {
            return bookRepo.AddItem(item);
        }

        public void UpdateBook(Book book)
        {
            this.bookRepo.Update(book);
        }
        public void UpdatePublisher(Publisher pub)
        {
            this.pubRepo.Update(pub);
        }
        public void UpdateAuthor(Author au)
        {
            this.autRepo.Update(au);
        }

        public Publisher AddPublisher(Publisher pub)
        {
            return pubRepo.AddItem(pub);
        }

        /// <summary>
        /// Forwards call to repository to change author name.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="newName"> Name to change item name into.</param>
        public void ChangeAuthorName(int index, string newName)
        {
            this.autRepo.ChangeAuthorName(index, newName);
        }

        /// <summary>
        /// Forwards call to repository to change book name.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="newName">Name to change item name into.</param>
        public void ChangeBookName(int index, string newName)
        {
            this.bookRepo.ChangeBookName(index, newName);
        }

        /// <summary>
        /// Forwards call to repository to change delivery days for publisher.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="days"> Number of days to change deliverydays into.</param>
        public void ChangeDeliveryDays(int index, int days)
        {
            this.pubRepo.ChangeDeliveryDays(index, days);
        }

        /// <summary>
        /// Forwards call to repository to change if author is forkids.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="forKids"> Bool value to change author forKids value into.</param>
        public void ChangeForKidsAuthor(int index, bool forKids)
        {
            this.autRepo.ChangeForKids(index, forKids);
        }

        /// <summary>
        /// Forwards call to repository to change if author is stil active.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="isActive"> Bool value to change author isActive into.</param>
        public void ChangeIsActiveAuthor(int index, bool isActive)
        {
            this.autRepo.ChangeIsActive(index, isActive);
        }

        /// <summary>
        /// Forwards call to repository to change if publisher is still active.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="isactive"> Bool value to change publisher isActive into.</param>
        public void ChangePublisherIsActive(int index, bool isactive)
        {
            this.pubRepo.ChangeIsActive(index, isactive);
        }

        /// <summary>
        /// Forwards call to repository to change language for publisher.
        /// </summary>
        /// <param name="index">Index of the item to modify.</param>
        /// <param name="language"> New language value.</param>
        public void ChangePublisherLanguage(int index, string language)
        {
            this.pubRepo.ChangeLanguage(index, language);
        }

        /// <summary>
        /// Forwards call to repository to change name for publisher.
        /// </summary>
        /// <param name="index">Index of the item to modify.</param>
        /// <param name="name"> New name value.</param>
        public void ChangePublisherName(int index, string name)
        {
            this.pubRepo.ChangePublisherName(index, name);
        }

        /// <summary>
        /// Forwards call to repository to change website for publisher.
        /// </summary>
        /// <param name="index"> Index of the item to modify.</param>
        /// <param name="website"> New website value.</param>
        public void ChangeWebsite(int index, string website)
        {
            this.pubRepo.ChangeWebpage(index, website);
        }

        /// <summary>
        /// Forwards call to repository to delete one author.
        /// </summary>
        /// <param name="index"> Index of the item to remove.</param>
        public void DeleteAuthor(int index)
        {
            this.autRepo.DeleteOne(index);
        }

        /// <summary>
        /// Forwards call to repository to delete one boook.
        /// </summary>
        /// <param name="index">Index of the item to remove.</param>
        public void DeleteBook(int index)
        {
            this.bookRepo.DeleteOne(index);
        }

        /// <summary>
        /// Forwards call to repository to delete one Publisher.
        /// </summary>
        /// <param name="index"> Index of the item to remove.</param>
        public void DeletePublisher(int index)
        {
            this.pubRepo.DeleteOne(index);
        }
    }
}
