using A9HNYJ_HFT_2021221.Repository;
using A9HNYJ_HFT_2021221.Logic;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using A9HNYJ_HFT_2021221.Models;
using System.Linq;
using System;

namespace A9HNYJ_HFT_2021221.Test
{
    /// <summary>
    /// Test class for AdminLogic class.
    /// </summary>
    public class AdminLogicTests
    {
        private Mock<IAuthorRepository> autrep;
        private Mock<IBookRepository> bookrep;
        private Mock<IPublisherRepository> pubrep;


        [Test]
        public void AddBookWithObjectTest()
        {
            var logic = this.LogicMockGenerator();
            logic.AddBook(new Book() { BookID = 16, AuthorID = 3, PublisherID = 5, Bookname = "Test", Price = 3000, Supply = 4, Year = 2041 });
            this.bookrep.Verify(x => x.AddItem(new Book { BookID = 16, AuthorID = 3, PublisherID = 5, Bookname = "Test", Price = 3000, Supply = 4, Year = 2041 }), Times.Once);
        }

        [Test]
        public void AddBookWithObjectWithNullasNameTest()
        {
            var logic = this.LogicMockGenerator();
            Assert.Throws<ArgumentException>(() => logic.AddBook(new Book() { BookID = 16, AuthorID = 3, PublisherID = 5, Bookname = null, Price = 3000, Supply = 4, Year = 2041 }));
        }

        [Test]
        public void AddPublisherWithObjectTest()
        {
            var logic = this.LogicMockGenerator();
            logic.AddPublisher(new Publisher() { PublisherID =6, PublisherName = "test", DelivareDays =5, IsActive = true, Language = "english", Webpage = "test.com"});
            this.pubrep.Verify(x => x.AddItem(new Publisher { PublisherID = 6, PublisherName = "test", DelivareDays = 5, IsActive = true, Language = "english", Webpage = "test.com" }), Times.Once);
        }


        /// <summary>
        /// Tests DeleteOneBook function. Uses verify only.
        /// </summary>
        [Test]
        public void DeleteOneBookTest()
        {
            var logic = this.LogicMockGenerator();
            logic.DeleteBook(1);
            this.bookrep.Verify(x => x.DeleteOne(1), Times.Once);
        }

        /// <summary>
        /// Tests DeleteOneAuthor function. Uses verify only.
        /// </summary>
        [Test]
        public void DeleteAuthorTest()
        {
            var logic = this.LogicMockGenerator();
            logic.DeleteAuthor(1);
            this.autrep.Verify(x => x.DeleteOne(1), Times.Once);
        }

        /// <summary>
        /// Tests ModifyAuthorName function. Uses verify only.
        /// </summary>
        [Test]
        public void ModifyAuthorNameTest()
        {
            var logic = this.LogicMockGenerator();
            
            logic.UpdateAuthor(new Author() { AuthorKey = 1, AuthorName = "test", YearBorn = 1821, IsActive = false, OriginalLanguage = "Russian", ForKids = false });
            this.autrep.Verify(x => x.Update(new Author() { AuthorKey = 1, AuthorName = "test", YearBorn = 1821, IsActive = false, OriginalLanguage = "Russian", ForKids = false }), Times.Once);
        }

        /// <summary>
        /// Tests ListAlaBooks function. Uses Asser and verify.
        /// </summary>
        [Test]
        public void ListAllBooksTest()
        {
            List<Book> books = new List<Book>()
            {
                new Book() { BookID = 1, AuthorID = 3, PublisherID = 5, Bookname = "Északi mitológia", Price = 3000, Supply = 4, Year = 2011 },
                new Book() { BookID = 2, AuthorID = 2, PublisherID = 1, Bookname = "Puszták népe", Price = 2800, Supply = 30, Year = 2016 },
                new Book() { BookID = 3, AuthorID = 2, PublisherID = 2, Bookname = "Puszták népe", Price = 300, Supply = 4, Year = 1976 },
                new Book() { BookID = 4, AuthorID = 1, PublisherID = 2, Bookname = "Feljegyzések az egérjukból", Price = 500, Supply = 2, Year = 1973 },
                new Book() { BookID = 5, AuthorID = 1, PublisherID = 1, Bookname = "Feljegyzések az egérjukból", Price = 4000, Supply = 30, Year = 2020 },
                new Book() { BookID = 6, AuthorID = 3, PublisherID = 4, Bookname = "Amecican Gods", Price = 4000, Supply = 3, Year = 2003 },
                new Book() { BookID = 7, AuthorID = 1, PublisherID = 3, Bookname = "Feljegyzések az egérjukból", Price = 800, Supply = 20, Year = 2017 },
            };

            var logic = this.LogicMockGenerator();
            var listofBooks = logic.GetAllBooks();
            this.bookrep.Verify(x => x.GetAll(), Times.Once);
            Assert.That(listofBooks, Is.EquivalentTo(books));
        }

        private AdminLogic LogicMockGenerator()
        {
            this.autrep = new Mock<IAuthorRepository>();
            this.bookrep = new Mock<IBookRepository>();
            this.pubrep = new Mock<IPublisherRepository>();

            List<Author> authors = new List<Author>()
            {
                new Author() { AuthorKey = 1, AuthorName = "Fjodor Mihajlovics Dosztojevszkij", YearBorn = 1821, IsActive = false, OriginalLanguage = "Russian", ForKids = false },
                new Author() { AuthorKey = 2, AuthorName = "Illyés Gyula", YearBorn = 1902, IsActive = false, OriginalLanguage = "Hungarian", ForKids = false },
                new Author() { AuthorKey = 3, AuthorName = "Neil Gaiman", YearBorn = 1960, IsActive = true, OriginalLanguage = "English", ForKids = true },
            };

            List<Publisher> publishers = new List<Publisher>()
            {
                new Publisher() { PublisherID = 1, PublisherName = "Szépirodalmi kiadó", Language = "Hungarian", Webpage = "szepirodalom.hu", DelivareDays = 5, IsActive = true },
                new Publisher() { PublisherID = 2, PublisherName = "Új Idõ KFT", Language = "Hungarian", Webpage = string.Empty, DelivareDays = 30, IsActive = false },
                new Publisher() { PublisherID = 3, PublisherName = "Zsebkönyv Kiadó", Language = "Hungarian", Webpage = "zsbekonyv.hu", DelivareDays = 3, IsActive = true },
                new Publisher() { PublisherID = 4, PublisherName = "UkBooks", Language = "English", Webpage = "ukBooks.hu", DelivareDays = 20, IsActive = true },
                new Publisher() { PublisherID = 5, PublisherName = "Tuan", Language = "Hungarian", Webpage = "tuan.hu", DelivareDays = 7, IsActive = true },
            };

            List<Book> books = new List<Book>()
            {
                new Book() { BookID = 1, AuthorID = 3, PublisherID = 5, Bookname = "Északi mitológia", Price = 3000, Supply = 4, Year = 2011 },
                new Book() { BookID = 2, AuthorID = 2, PublisherID = 1, Bookname = "Puszták népe", Price = 2800, Supply = 30, Year = 2016 },
                new Book() { BookID = 3, AuthorID = 2, PublisherID = 2, Bookname = "Puszták népe", Price = 300, Supply = 4, Year = 1976 },
                new Book() { BookID = 4, AuthorID = 1, PublisherID = 2, Bookname = "Feljegyzések az egérjukból", Price = 500, Supply = 2, Year = 1973 },
                new Book() { BookID = 5, AuthorID = 1, PublisherID = 1, Bookname = "Feljegyzések az egérjukból", Price = 4000, Supply = 30, Year = 2020 },
                new Book() { BookID = 6, AuthorID = 3, PublisherID = 4, Bookname = "Amecican Gods", Price = 4000, Supply = 3, Year = 2003 },
                new Book() { BookID = 7, AuthorID = 1, PublisherID = 3, Bookname = "Feljegyzések az egérjukból", Price = 800, Supply = 20, Year = 2017 },
            };

            this.autrep.Setup(repo => repo.GetAll()).Returns(authors.AsQueryable);
            this.bookrep.Setup(repo => repo.GetAll()).Returns(books.AsQueryable);
            this.pubrep.Setup(repo => repo.GetAll()).Returns(publishers.AsQueryable);
            return new AdminLogic(this.bookrep.Object, this.pubrep.Object, this.autrep.Object);
        }
    }
}