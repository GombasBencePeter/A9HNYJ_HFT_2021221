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
        public UILogic(RestCollection<Book> books, RestCollection<Author> authors, RestCollection<Publisher> publishers)
        {
            Books = books;
            Authors = authors;
            Publishers = publishers;
        }

        public RestCollection<Book> Books { get; set; }
        public RestCollection<Author> Authors { get; set; }
        public RestCollection<Publisher> Publishers { get; set; }


        public void AddAuthor()
        {
            AddOrModifyAuthor add = new AddOrModifyAuthor();
            if (add.ShowDialog() == true)
            {
                if(Authors.FirstOrDefault(x => x.AuthorKey == add.ChosenAuthor.AuthorKey)!= null)
                {
                    Authors.Add(add.ChosenAuthor);
                }
            }
            
        }

        public void ModifyAuthor(Author author)
        {
            Author author1 = new Author { AuthorKey = author.AuthorKey, AuthorName = author.AuthorName, 
                Books = author.Books, ForKids = author.ForKids, IsActive = author.IsActive, 
                OriginalLanguage = author.OriginalLanguage, YearBorn = author.YearBorn };
            AddOrModifyAuthor add = new AddOrModifyAuthor(author1);
            if (add.ShowDialog() == true)
            {
                    Authors.Update(add.ChosenAuthor);
                
            }

        }
    }
}
