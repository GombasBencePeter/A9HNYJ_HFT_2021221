using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Data;
using Microsoft.EntityFrameworkCore;
using A9HNYJ_HFT_2021221.Models;


namespace A9HNYJ_HFT_2021221.Repository
{
    /// <summary>
    /// Repository for handling "Book" table. Inherits form Repository.
    /// </summary>
    public class BookRepository : Repository<Book>, IBookRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="context"> Common Db context. </param>
        public BookRepository(DbContext context)
            : base(context)
        {
        }

        public void Update(Book book)
        {
            Book b = this.GetOne(book.BookID);
            b.Bookname = book.Bookname;
            b.AuthorID = book.AuthorID;
            b.Price = book.Price;
            b.PublisherID = book.PublisherID;
            b.Supply = book.Supply;
            b.Year = book.Year;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Changes Book name and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newName"> New name. </param>
        public void ChangeBookName(int index, string newName)
        {
            this.GetOne(index).Bookname = newName;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Changes Book price and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newPrice"> New price.</param>
        public void ChangePrice(int index, int newPrice)
        {
            this.GetOne(index).Price = newPrice;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Changes book supply and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="changeVal"> New Supply. </param>
        public void ChangeSupply(int index, int changeVal)
        {
            this.GetOne(index).Supply = changeVal;
            this.Context.SaveChanges();
        }
    }
}
