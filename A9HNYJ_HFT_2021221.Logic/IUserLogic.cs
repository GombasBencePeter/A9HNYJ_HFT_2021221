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
    /// Interface for user class that includes user funcionalities.
    /// </summary>
    public interface IUserLogic
    {
        /// <summary>
        /// Repository call to get all items form "Books" table form db.
        /// </summary>
        /// <returns> List with Book instances. List with all items in the table "Books".</returns>
        IEnumerable<Book> GetAllBooks();

        /// <summary>
        /// Repository call to get all items form "Publishers" table form db.
        /// </summary>
        /// <returns> List of Publisher instances. List with all items in the table "Publishers".</returns>
        IEnumerable<Publisher> GetAllPublishers();

        /// <summary>
        /// Repository call to get all items form "Authors" table form db.
        /// </summary>
        /// <returns> List with Author instances. List with all items in the table "Authors".</returns>
        IEnumerable<Author> GetAllAuthors();

        /// <summary>
        /// Repository call to get one Book item with the given index.
        /// </summary>
        /// <param name="index"> The index of the item to be found.</param>
        /// <returns> One Book instance with the corresponting index. </returns>
        Book OneBook(int index);

        /// <summary>
        /// Repository call to get one Publisher item with the given index.
        /// </summary>
        /// <param name="index"> The index of the item to be found.</param>
        /// <returns> One Publisher instance with the corresponting index. </returns>
        Publisher OnePublisher(int index);

        /// <summary>
        /// Repository call to get one Author item with the given index.
        /// </summary>
        /// <param name="index"> The index of the item to be found.</param>
        /// <returns> One Author instance with the corresponding index. </returns>
        Author OneAuthor(int index);


        public IEnumerable<ListBooksWithLessThan10PcsReturnValue> ListBooksWithLessThan10PcsWith10DayDelivery();
       

        public IEnumerable<ListAllAuthorsEditionsReturnValue> ListAllAuthorsHowManyEditions();

        /// <summary>
        /// Query to get all books where the authors original language and the publishers language is "English", where the Author writes kid friendly books and was released after 1990.
        /// </summary>
        /// <returns> List with the Book resoults of the query. </returns>
        IEnumerable<Book> ListEnglishBookForKids();

        /// <summary>
        /// Query to get all new edition books wich has an old edition published. The new editions publisher is active, while the old editions publisher is not active.
        /// </summary>
        /// <returns> List with the Book resoults of the query.</returns>
        IEnumerable<Book> ListNewBooksWithOldEditions();
    }
}
