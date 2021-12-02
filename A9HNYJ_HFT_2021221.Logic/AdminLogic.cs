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

        /// <summary>
        /// Forwards values to repository to create new Author item.
        /// </summary>
        /// <param name="authorname"> authroname for new author. </param>
        /// <param name="yearborn"> yearborn for new author. </param>
        /// <param name="isactive"> isactive for new author. </param>
        /// <param name="originallanguage"> originallanguage for new author. </param>
        /// <param name="forkids"> forkids for new author. </param>
        /// <returns> The Author item created. Null if not successful. </returns>
        public Author AddAuthor(string authorname, int yearborn, bool isactive, string originallanguage, bool forkids)
        {
            return this.autRepo.AddAuthor(authorname, yearborn, isactive, originallanguage, forkids);
        }

        public Author AddAuthor(Author aut)
        {
            return autRepo.AddItem(aut);
        }

        public Book AddBook(Book item)
        {
            return bookRepo.AddItem(item);
        }

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
        public Book AddBook(string authorname, string publishername, string bookname, int price, int supply, int year)
        {
            var p = this.pubRepo.GetAll().FirstOrDefault(x => x.PublisherName.ToUpper() == publishername.ToUpper());
            if (p == null)
            {
                return null;
            }
            else
            {
                var a = this.autRepo.GetAll().FirstOrDefault(x => x.AuthorName.ToUpper() == authorname.ToUpper());
                if (a == null)
                {
                    return null;
                }
                else
                {
                    return this.bookRepo.AddBook(a.AuthorKey, p.PublisherID, bookname, price, supply, year);
                }
            }
        }

        /// <summary>
        /// Forwards values to repository, to create new publisher item.
        /// </summary>
        /// <param name="publishername"> Name for new Publisher. </param>
        /// <param name="language"> Language for new publisher. </param>
        /// <param name="webpage"> Webpage of new publisher. </param>
        /// <param name="deliverydays">Delivery days number for new publisher. </param>
        /// <param name="isactive"> Isactive for new publisher. </param>
        /// <returns> New publisher item or null if not successful.</returns>
        public Publisher AddPublisher(string publishername, string language, string webpage, int deliverydays, bool isactive)
        {
            return this.pubRepo.AddPublisher(publishername, language, webpage, deliverydays, isactive);
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
