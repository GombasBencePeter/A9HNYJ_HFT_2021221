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
    /// Repository for handling "Author" table. Inherits from Repository.
    /// </summary>
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorRepository"/> class.
        /// </summary>
        /// <param name="context"> Common Db Context. </param>
        public AuthorRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Changes author name and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newName"> New value. </param>
        public void ChangeAuthorName(int index, string newName)
        {
            this.GetOne(index).AuthorName = newName;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Changes author forKids value and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="forKids"> New value. </param>
        public void ChangeForKids(int index, bool forKids)
        {
            this.GetOne(index).ForKids = forKids;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Changes author isActive value and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify. </param>
        /// <param name="isActive"> New value. </param>
        public void ChangeIsActive(int index, bool isActive)
        {
            this.GetOne(index).IsActive = isActive;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Adds new author item and saves changes.
        /// </summary>
        /// <param name="name"> Name of author. </param>
        /// <param name="yearborn"> The year the author vas born. </param>
        /// <param name="isActive"> The author isActive value.</param>
        /// <param name="originallanguage"> Original language of the author.</param>
        /// <param name="forkids"> Author forKids value. </param>
        /// <returns> New value or null.</returns>
        public Author AddAuthor(string name, int yearborn, bool isActive, string originallanguage, bool forkids)
        {
            Author newAuthor = new Author() { AuthorName = name, YearBorn = yearborn, IsActive = isActive, OriginalLanguage = originallanguage, ForKids = forkids };
            this.Context.Add(newAuthor);
            this.Context.SaveChanges();
            return newAuthor;
        }
    }
}
