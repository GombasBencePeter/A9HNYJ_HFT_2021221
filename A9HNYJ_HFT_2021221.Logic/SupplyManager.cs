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
