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

        public void Update(Author author)
        {
            Author a = this.GetOne(author.AuthorKey);
            a.AuthorName = author.AuthorName;
            a.OriginalLanguage = author.OriginalLanguage;
            a.ForKids = author.ForKids;
            a.IsActive = author.IsActive;
            a.YearBorn = author.YearBorn;
            this.Context.SaveChanges();
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
    }
}
