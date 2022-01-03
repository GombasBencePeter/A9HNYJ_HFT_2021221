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

        public void AddAuthor(Author aut)
        {
            if (aut.AuthorName == null || aut.IsActive == null || aut.ForKids == null)
            {
                throw new ArgumentException();
            }

            autRepo.AddItem(aut);
        }

        public void AddBook(Book item)
        {
            if(item.Bookname == null || item.PublisherID == null || item.AuthorID== null)
            {
                throw new ArgumentException();
            }

            bookRepo.AddItem(item);
        }

        public void AddPublisher(Publisher pub)
        {
            if(pub.PublisherName == null || pub.Language == null)
            {
                throw new ArgumentException();
            }
            pubRepo.AddItem(pub);
            
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
