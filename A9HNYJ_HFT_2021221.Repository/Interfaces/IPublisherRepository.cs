using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Data;
using A9HNYJ_HFT_2021221.Models;


namespace A9HNYJ_HFT_2021221.Repository
{
    /// <summary>
    /// INterface for implementing repository for handling table "publisher".
    /// </summary>
    public interface IPublisherRepository : IRepository<Publisher>
    {
        /// <summary>
        /// Changes publisher name and saves changes.
        /// </summary>
        /// <param name="index">  Index of item to modify.</param>
        /// <param name="newName"> New name.</param>
        void ChangePublisherName(int index, string newName);

        void Update(Publisher pub);

        /// <summary>
        /// Changes publishing language and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newLanguage"> New language. </param>
        void ChangeLanguage(int index, string newLanguage);

        /// <summary>
        /// Changes website and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newWebpage"> New webpage. </param>
        void ChangeWebpage(int index, string newWebpage);

        /// <summary>
        /// Changes delivery days and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="days"> New delivery days.</param>
        void ChangeDeliveryDays(int index, int days);

        /// <summary>
        /// Changes isActive and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newIsActive"> New isActive. </param>
        void ChangeIsActive(int index, bool newIsActive);

    }
}
