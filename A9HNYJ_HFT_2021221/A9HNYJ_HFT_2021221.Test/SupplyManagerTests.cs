using A9HNYJ_HFT_2021221.Data;
using A9HNYJ_HFT_2021221.Logic;
using A9HNYJ_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9HNYJ_HFT_2021221.Test
{
    /// <summary>
    /// Test class for SupplyManager class.
    /// </summary>
    public class SupplyManagerTests
    {
        private Mock<IAuthorRepository> autrep;
        private Mock<IBookRepository> bookrep;
        private Mock<IPublisherRepository> pubrep;

        /// <summary>
        /// Tests ChangeSupply function. Uses verify only.
        /// </summary>
        [Test]
        public void ChangeSupplyTest()
        {
            var logic = this.LogicMockGenerator();
            logic.ChangeSupply(1, 10);
            this.bookrep.Verify(x => x.ChangeSupply(1, 10), Times.Once());
        }

        private SupplyManager LogicMockGenerator()
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
                new Publisher() { PublisherID = 2, PublisherName = "Új Idő KFT", Language = "Hungarian", Webpage = string.Empty, DelivareDays = 30, IsActive = false },
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
            return new SupplyManager(this.bookrep.Object, this.pubrep.Object, this.autrep.Object);
        }
    }
}
