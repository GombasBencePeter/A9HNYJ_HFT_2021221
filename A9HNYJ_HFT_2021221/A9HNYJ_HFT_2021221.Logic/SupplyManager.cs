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
    /// Logic class for SupplyManager functions. Inherits user functions from UserLogic class.
    /// </summary>
    public class SupplyManager : UserLogic, ISupplyManager
    {
        private IBookRepository bookRepo;
        private IPublisherRepository pubRepo;
        private IAuthorRepository autRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplyManager"/> class.
        /// </summary>
        /// <param name="br"> IBookRepository implementing class. </param>
        /// <param name="pr"> IPublisherRepository implementing class. </param>
        /// <param name="ar"> IAuthorRepository implementing class. </param>
        public SupplyManager(IBookRepository br, IPublisherRepository pr, IAuthorRepository ar)
            : base(br, pr, ar)
        {
            this.bookRepo = br;
            this.pubRepo = pr;
            this.autRepo = ar;
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
            var p = this.pubRepo.GetAll().FirstOrDefault(x => x.PublisherName.ToUpper().Contains(publishername.ToUpper()));
            if (p == null)
            {
                return null;
            }
            else
            {
                var a = this.autRepo.GetAll().FirstOrDefault(x => x.AuthorName.ToUpper().Contains(authorname.ToUpper()));
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
        /// Forwards call to repository to add to the current supply of one book. Checks if new amount is positive. If not nothing happens.
        /// </summary>
        /// <param name="index"> Index of the item to modify. </param>
        /// <param name="valToAdd"> Amount to add. </param>
        public void AddSupply(int index, int valToAdd)
        {
            int newval = this.bookRepo.GetOne(index).Supply + valToAdd;
            if (newval >= 0)
            {
                this.bookRepo.ChangeSupply(index, newval);
            }
        }

        /// <summary>
        /// FOrwards call to repository to change the price of one book.
        /// </summary>
        /// <param name="index"> Index of the item to modify. </param>
        /// <param name="newprice"> New price of the book (only positive number). </param>
        public void ChangePrice(int index, int newprice)
        {
            if (newprice >= 0)
            {
                this.bookRepo.ChangePrice(index, newprice);
            }
        }

        /// <summary>
        /// Forwards call to repository to change the current supply of one book.
        /// </summary>
        /// <param name="index"> Index of the item to modify. </param>
        /// <param name="newSupply"> New supply of that book (only positive number). </param>
        public void ChangeSupply(int index, int newSupply)
        {
            if (newSupply >= 0)
            {
                this.bookRepo.ChangeSupply(index, newSupply);
            }
        }
    }
}
