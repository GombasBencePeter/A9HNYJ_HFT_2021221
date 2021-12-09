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

    }
}
