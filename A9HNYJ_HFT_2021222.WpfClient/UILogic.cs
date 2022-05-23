using A9HNYJ_HFT_2021221.Models;
using A9HNYJ_HFT_2021222.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9HNYJ_HFT_2021222.WpfClient
{
    public class UILogic
    {
        public UILogic()
        {
        }



        public void AddAuthor( RestCollection<Author> authors)
        {
            AddOrModifyAuthor add = new AddOrModifyAuthor();
            if (add.ShowDialog() == true)
            {
                authors.Add(add.ChosenAuthor);

            }
            
        }

        public void ModifyAuthor(Author author, RestCollection<Author> authors)
        {
            Author author1 = new Author
            {
                AuthorKey = author.AuthorKey,
                AuthorName = author.AuthorName,
                Books = author.Books,
                ForKids = author.ForKids,
                IsActive = author.IsActive,
                OriginalLanguage = author.OriginalLanguage,
                YearBorn = author.YearBorn
            };
            AddOrModifyAuthor add = new AddOrModifyAuthor(author1);
            if (add.ShowDialog() == true)
            {
                    authors.Update(author1);
                
            }

        }

        internal void AddBook(RestCollection<Book> books)
        {
            AddOrModifyBook add = new AddOrModifyBook();
            if (add.ShowDialog() == true)
            {
                books.Add(add.ChosenBook);
            }
        }

        internal void ModifyBook(Book selectedBook, RestCollection<Book> books)
        {
            Book book = new Book()
            {
                BookID = selectedBook.BookID,
                AuthorID = selectedBook.AuthorID,
                PublisherID = selectedBook.PublisherID,
                Bookname = selectedBook.Bookname,
                Price = selectedBook.Price,
                Supply = selectedBook.Supply,
                Year = selectedBook.Year
            };
            AddOrModifyBook mod = new AddOrModifyBook(book);
            if(mod.ShowDialog() == true)
            {
                books.Update(book);
            }
        }

        internal void AddPublisher(RestCollection<Publisher> publishers)
        {
            AddOrModifyPublisher add = new AddOrModifyPublisher();
            if(add.ShowDialog() == true)
            {
                publishers.Add(add.ChosenPublisher);
            }
        }

        internal void ModifyPublisher(Publisher selectedPublisher, RestCollection<Publisher> publishers)
        {
            Publisher publisher = new Publisher()
            {
                PublisherName = selectedPublisher.PublisherName,
                PublisherID = selectedPublisher.PublisherID,
                Language = selectedPublisher.Language,
                Webpage = selectedPublisher.Webpage,
                DelivareDays = selectedPublisher.DelivareDays,
                IsActive = selectedPublisher.IsActive
            };
            AddOrModifyPublisher mod = new AddOrModifyPublisher(publisher);
            if(mod.ShowDialog() == true)
            {
                publishers.Update(publisher);
            }
        }
    }
}
