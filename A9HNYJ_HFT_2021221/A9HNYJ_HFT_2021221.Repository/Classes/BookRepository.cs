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

        /// <summary>
        /// Changes Book name and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newName"> New name. </param>
        public void ChangeBookName(int index, string newName)
        {
            this.GetOne(index).Bookname = newName;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Changes Book price and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newPrice"> New price.</param>
        public void ChangePrice(int index, int newPrice)
        {
            this.GetOne(index).Price = newPrice;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Changes book supply and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="changeVal"> New Supply. </param>
        public void ChangeSupply(int index, int changeVal)
        {
            this.GetOne(index).Supply = changeVal;
            this.context.SaveChanges();
        }

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
        public Book AddBook(int author, int publisher, string bookname, int price, int supply, int year)
        {
            Book newBook = new Book() { AuthorID = author, PublisherID = publisher, Bookname = bookname, Price = price, Supply = supply, Year = year };
            this.context.Add(newBook);
            this.context.SaveChanges();
            return newBook;
        }
    }
}
