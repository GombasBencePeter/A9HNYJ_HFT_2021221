using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Models;
using A9HNYJ_HFT_2021221.Data;

namespace A9HNYJ_HFT_2021221.Repository
{
    /// <summary>
    /// Interface for implementing repository for "Author" table.
    /// </summary>
    public interface IAuthorRepository : IRepository<Author>
    {
        /// <summary>
        /// Changes author name and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newName"> New value. </param>
        void ChangeAuthorName(int index, string newName);

        /// <summary>
        /// Changes author isActive value and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify. </param>
        /// <param name="isActive"> New value. </param>
        void ChangeIsActive(int index, bool isActive);

        /// <summary>
        /// Changes author forKids value and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="forKids"> New value. </param>
        void ChangeForKids(int index, bool forKids);

        void Update(Author aut);

        /// <summary>
        /// Adds new author item and saves changes.
        /// </summary>
        /// <param name="name"> Name of author. </param>
        /// <param name="yearborn"> The year the author vas born. </param>
        /// <param name="isActive"> The author isActive value.</param>
        /// <param name="originallanguage"> Original language of the author.</param>
        /// <param name="forkids"> Author forKids value. </param>
        /// <returns> New value or null.</returns>
        public Author AddAuthor(string name, int yearborn, bool isActive, string originallanguage, bool forkids);
    }
}
