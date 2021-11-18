using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Models;

namespace A9HNYJ_HFT_2021221.Data
{
    /// <summary>
    /// Costom context for database, inherits from DbContext.
    /// </summary>
    public class BookStoreContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreContext"/> class.
        /// </summary>
        public BookStoreContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreContext"/> class.
        /// </summary>
        /// <param name="options"> Custom otions for the constructor.</param>
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets db Set with Book entites.
        /// </summary>
        public virtual DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets db Set with Publisher entites.
        /// </summary>
        public virtual DbSet<Publisher> Publishers { get; set; }

        /// <summary>
        /// Gets or sets db Set with Author entites.
        /// </summary>
        public virtual DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Configuring optionsBuilder.
        /// </summary>
        /// <param name="optionsBuilder"> OptionsBilder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;ATTACHDbFilename=|DataDirectory|\BookData.mdf;Integrated Security=true;MultipleActiveResultSets=true");
            }
        }

        /// <summary>
        /// Creating Database structure and content.
        /// </summary>
        /// <param name="modelBuilder"> Modelbuilder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Author a1 = new Author() { AuthorKey = 1, AuthorName = "Andrzej Sapkowski", YearBorn = 1948, IsActive = true, OriginalLanguage = "Polish", ForKids = false };
            Author a2 = new Author() { AuthorKey = 2, AuthorName = "Neil Gaiman", YearBorn = 1960, IsActive = true, OriginalLanguage = "English", ForKids = true };
            Author a3 = new Author() { AuthorKey = 3, AuthorName = "Fjodor Mihajlovics Dosztojevszkij", YearBorn = 1821, IsActive = false, OriginalLanguage = "Russian", ForKids = false };
            Author a4 = new Author() { AuthorKey = 4, AuthorName = "Richard Feynman", YearBorn = 1918, IsActive = false, OriginalLanguage = "English", ForKids = true };
            Author a5 = new Author() { AuthorKey = 5, AuthorName = "Illyés Gyula", YearBorn = 1902, IsActive = false, OriginalLanguage = "Hungarian", ForKids = false };
            Author a6 = new Author() { AuthorKey = 6, AuthorName = "Suzanne Collins", YearBorn = 1962, IsActive = true, OriginalLanguage = "English", ForKids = true };
            Author a7 = new Author() { AuthorKey = 7, AuthorName = "Loisa May Acott", YearBorn = 1832, IsActive = false, OriginalLanguage = "English", ForKids = true };

            Publisher p1 = new Publisher() { PublisherID = 1, PublisherName = "Szépirodalmi kiadó", Language = "Hungarian", Webpage = "szepirodalom.hu", DelivareDays = 5, IsActive = true };
            Publisher p2 = new Publisher() { PublisherID = 2, PublisherName = "UkBooks", Language = "English", Webpage = "ukBooks.hu", DelivareDays = 20, IsActive = true };
            Publisher p3 = new Publisher() { PublisherID = 3, PublisherName = "Tuan", Language = "Hungarian", Webpage = "tuan.hu", DelivareDays = 7, IsActive = true };
            Publisher p4 = new Publisher() { PublisherID = 4, PublisherName = "Új Idő KFT", Language = "Hungarian", Webpage = string.Empty, DelivareDays = 30, IsActive = false };
            Publisher p5 = new Publisher() { PublisherID = 5, PublisherName = "TudományosKiado", Language = "Hungarian", Webpage = "tudomanyoskiado.hu", DelivareDays = 5, IsActive = true };
            Publisher p6 = new Publisher() { PublisherID = 6, PublisherName = "Zsebkönyv Kiadó", Language = "Hungarian", Webpage = "zsbekonyv.hu", DelivareDays = 3, IsActive = true };

            Book b1 = new Book() { BookID = 1, AuthorID = 4, PublisherID = 5, Bookname = "Előadások fizikából", Price = 4000, Supply = 10, Year = 2007 };
            Book b2 = new Book() { BookID = 2, AuthorID = 2, PublisherID = 3, Bookname = "Északi mitológia", Price = 3000, Supply = 4, Year = 2011 };
            Book b3 = new Book() { BookID = 3, AuthorID = 5, PublisherID = 1, Bookname = "Puszták népe", Price = 2800, Supply = 30, Year = 2016 };
            Book b4 = new Book() { BookID = 4, AuthorID = 5, PublisherID = 4, Bookname = "Puszták népe", Price = 300, Supply = 4, Year = 1976 };
            Book b5 = new Book() { BookID = 5, AuthorID = 1, PublisherID = 3, Bookname = "Vaják", Price = 3300, Supply = 30, Year = 2009 };
            Book b6 = new Book() { BookID = 6, AuthorID = 3, PublisherID = 4, Bookname = "Feljegyzések az egérjukból", Price = 500, Supply = 2, Year = 1973 };
            Book b7 = new Book() { BookID = 7, AuthorID = 3, PublisherID = 1, Bookname = "Feljegyzések az egérjukból", Price = 4000, Supply = 30, Year = 2020 };
            Book b8 = new Book() { BookID = 8, AuthorID = 2, PublisherID = 2, Bookname = "Amecican Gods", Price = 4000, Supply = 3, Year = 2003 };
            Book b9 = new Book() { BookID = 9, AuthorID = 6, PublisherID = 2, Bookname = "Hunger Games", Price = 4000, Supply = 10, Year = 2008 };
            Book b10 = new Book() { BookID = 10, AuthorID = 7, PublisherID = 2, Bookname = "Little Women", Price = 3500, Supply = 8, Year = 1868 };
            Book b11 = new Book() { BookID = 11, AuthorID = 6, PublisherID = 2, Bookname = "Catching fire", Price = 4000, Supply = 12, Year = 2009 };
            Book b12 = new Book() { BookID = 12, AuthorID = 1, PublisherID = 2, Bookname = "The Witcher", Price = 4200, Supply = 8, Year = 1993 };
            Book b13 = new Book() { BookID = 13, AuthorID = 3, PublisherID = 6, Bookname = "Feljegyzések az egérjukból", Price = 800, Supply = 20, Year = 2017 };

            modelBuilder.Entity<Author>().HasData(a1, a2, a3, a4, a5, a6, a7);
            modelBuilder.Entity<Publisher>().HasData(p1, p2, p3, p4, p5, p6);
            modelBuilder.Entity<Book>().HasData(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13);
        }
    }
}
