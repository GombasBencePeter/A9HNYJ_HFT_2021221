using A9HNYJ_HFT_2021221.Data;
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
    /// The class containg functions for the user access of the database.
    /// </summary>
    public class UserLogic : IUserLogic
    {
        private IBookRepository bookRepo;
        private IPublisherRepository pubRepo;
        private IAuthorRepository autRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogic"/> class.
        /// </summary>
        /// <param name="br"> BookRepository instance for connection to repo layer.</param>
        /// <param name="pr"> PublisherRepository instance for connection to repo layer.</param>
        /// <param name="ar"> AuthorRepository instance for connection to repo layer.</param>
        public UserLogic(IBookRepository br, IPublisherRepository pr, IAuthorRepository ar)
        {
            this.bookRepo = br;
            this.pubRepo = pr;
            this.autRepo = ar;
        }

        /// <summary>
        /// Repository call to get all items form "Authors" table form db.
        /// </summary>
        /// <returns> List with Author instances. List with all items in the table "Authors".</returns>
        public List<Author> ListAllAuthors()
        {
            return this.autRepo.GetAll().ToList();
        }

        /// <summary>
        /// Repository call to get all items form "Books" table form db.
        /// </summary>
        /// <returns> List with Book instances. List with all items in the table "Books".</returns>
        public List<Book> ListAllBooks()
        {
            return this.bookRepo.GetAll().ToList();
        }

        /// <summary>
        /// Repository call to get all items form "Publishers" table form db.
        /// </summary>
        /// <returns> List of Publisher instances. List with all items in the table "Publishers".</returns>
        public List<Publisher> ListAllPublishers()
        {
            return this.pubRepo.GetAll().ToList();
        }

        /// <summary>
        /// Repository call to get one Author item with the given index.
        /// </summary>
        /// <param name="index"> The index of the item to be found.</param>
        /// <returns> One Author instance with the corresponding index. </returns>
        public Author OneAuthor(int index)
        {
            return this.autRepo.GetOne(index);
        }

        /// <summary>
        /// Repository call to get one Book item with the given index.
        /// </summary>
        /// <param name="index"> The index of the item to be found.</param>
        /// <returns> One Book instance with the corresponting index. </returns>
        public Book OneBook(int index)
        {
            return this.bookRepo.GetOne(index);
        }

        /// <summary>
        /// Repository call to get one Publisher item with the given index.
        /// </summary>
        /// <param name="index"> The index of the item to be found.</param>
        /// <returns> One Publisher instance with the corresponting index. </returns>
        public Publisher OnePublisher(int index)
        {
            return this.pubRepo.GetOne(index);
        }

        /// <summary>
        /// Query to get all books where the authors original language and the publishers language is "English", where the Author writes kid friendly books and was released after 1990.
        /// </summary>
        /// <returns> List with the Book resoults of the query. </returns>
        public List<Book> ListEnglishBookForKids()
        {
            var query =
                from i in this.bookRepo.GetAll()
                join t in this.pubRepo.GetAll() on i.PublisherID equals t.PublisherID
                join a in this.autRepo.GetAll() on i.AuthorID equals a.AuthorKey
                where a.OriginalLanguage == "English" && t.Language == "English" && a.ForKids == true && i.Year >= 1990
                select i;

            return query.ToList();
        }

        /// <summary>
        /// Query to get all books with less than 10 pcs in inventory, can be delivered withing 10 days and the publisher is active.
        /// </summary>
        /// <returns> List with custom return object "ListBooksWithLessThan10PcsReturnValue", which contains the title of the book, the name of the publisher, the supply currently present and the number of days it takes to deliver.</returns>
        public List<ListBooksWithLessThan10PcsReturnValue> ListBooksWithLessThan10PcsWith10DayDelivery()
        {
            var query =
                from i in this.bookRepo.GetAll()
                join t in this.pubRepo.GetAll() on i.PublisherID equals t.PublisherID
                where i.Supply < 10 && t.DelivareDays < 10 && t.IsActive == true
                select new ListBooksWithLessThan10PcsReturnValue { Title = i.Bookname, Publisher = t.PublisherName, Supply = i.Supply, Days = t.DelivareDays };

            return query.ToList();
        }

        /// <summary>
        /// Query to get for each author in the db how many languages do the have publications in.
        /// </summary>
        /// <returns> List with custom return object "ListAllAuthorsEditionsReturnValue", which contains the name of the author and the number of languages the have publications in.</returns>
        public List<ListAllAuthorsEditionsReturnValue> ListAllAuthorsHowManyEditions()
        {
            var query =
                from i in this.bookRepo.GetAll()
                join t in this.pubRepo.GetAll() on i.PublisherID equals t.PublisherID
                join a in this.autRepo.GetAll() on i.AuthorID equals a.AuthorKey
                group a by a.AuthorName into g
                select new ListAllAuthorsEditionsReturnValue { Name = g.Key, Editions = g.Count() };

            return query.ToList();
        }

        /// <summary>
        /// Query to get all new edition books wich has an old edition published. The new editions publisher is active, while the old editions publisher is not active.
        /// </summary>
        /// <returns> List with the Book resoults of the query.</returns>
        public List<Book> ListNewBooksWithOldEditions()
        {
            var query =
                from i in this.bookRepo.GetAll()
                join t in this.pubRepo.GetAll() on i.PublisherID equals t.PublisherID
                where t.IsActive == false
                select i;

            var query2 =
                 from i in this.bookRepo.GetAll()
                 join t in this.pubRepo.GetAll() on i.PublisherID equals t.PublisherID
                 where t.IsActive == true && query.FirstOrDefault(x => x.Bookname.ToUpper() == i.Bookname.ToUpper()) != null
                 select i;

            return query2.ToList();
        }

        /// <summary>
        /// Calls ListNewBooksWithOldEditions() query function locally, creates Task.
        /// </summary>
        /// <returns> Task of the query function ListNewBooksWithOldEditions(). </returns>
        public Task<List<Book>> ListNewBooksWithOldEditionsAsync()
        {
            return Task<List<Book>>.Factory.StartNew(this.ListNewBooksWithOldEditions);
        }

        /// <summary>
        /// Calls ListAllAuthorsHowManyEditions() query function locally, creates Task.
        /// </summary>
        /// <returns> Task of the query function ListAllAuthorsHowManyEditions(). </returns>
        public Task<List<ListAllAuthorsEditionsReturnValue>> ListAllAuthorsHowManyEditionsAsync()
        {
            return Task<List<ListAllAuthorsEditionsReturnValue>>.Factory.StartNew(this.ListAllAuthorsHowManyEditions);
        }

        /// <summary>
        /// Calls ListBooksWithLessThan10PcsWith10DayDelivery() query function locally, creates Task.
        /// </summary>
        /// <returns> Task of the query function ListBooksWithLessThan10PcsWith10DayDelivery(). </returns>
        public Task<List<ListBooksWithLessThan10PcsReturnValue>> ListBooksWithLessThan10PcsWith10DayDeliveryAsync()
        {
            return Task<List<ListBooksWithLessThan10PcsReturnValue>>.Factory.StartNew(this.ListBooksWithLessThan10PcsWith10DayDelivery);
        }

        /// <summary>
        /// Calls ListEnglishBookForKids() query function locally, creates Task.
        /// </summary>
        /// <returns> Task of the query function ListEnglishBookForKids(). </returns>
        public Task<List<Book>> ListEnglishBookForKidsAsync()
        {
            return Task<List<Book>>.Factory.StartNew(this.ListEnglishBookForKids);
        }
    }
}
