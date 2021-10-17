﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Data;
using Microsoft.EntityFrameworkCore;

namespace A9HNYJ_HFT_2021221.Repository
{
    /// <summary>
    /// Repository for handling "Publisher" table. Inherits form Repository.
    /// </summary>
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublisherRepository"/> class.
        /// </summary>
        /// <param name="context"> Common Db context. </param>
        public PublisherRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Changes delivery days and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="days"> New delivery days.</param>
        public void ChangeDeliveryDays(int index, int days)
        {
            this.GetOne(index).DelivareDays = days;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Changes isActive and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newIsActive"> New isActive. </param>
        public void ChangeIsActive(int index, bool newIsActive)
        {
            this.GetOne(index).IsActive = newIsActive;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Changes publishing language and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newLanguage"> New language. </param>
        public void ChangeLanguage(int index, string newLanguage)
        {
            this.GetOne(index).Language = newLanguage;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Changes publisher name and saves changes.
        /// </summary>
        /// <param name="index">  Index of item to modify.</param>
        /// <param name="newName"> New name.</param>
        public void ChangePublisherName(int index, string newName)
        {
            this.GetOne(index).PublisherName = newName;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Changes website and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to modify.</param>
        /// <param name="newWebpage"> New webpage. </param>
        public void ChangeWebpage(int index, string newWebpage)
        {
            this.GetOne(index).Webpage = newWebpage;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Adds new publisher item to the table.
        /// </summary>
        /// <param name="name"> Name of publisher.</param>
        /// <param name="language"> Publishing language.</param>
        /// <param name="webpage"> Webpage link.</param>
        /// <param name="deliverydays"> Delivery days.</param>
        /// <param name="isactive"> Is the publisher active?. </param>
        /// <returns> New publisher item or null.</returns>
        public Publisher AddPublisher(string name, string language, string webpage, int deliverydays, bool isactive)
        {
            Publisher newPublisher = new Publisher() { PublisherName = name, Language = language, Webpage = webpage, DelivareDays = deliverydays, IsActive = isactive };
            this.context.Add(newPublisher);
            this.context.SaveChanges();
            return newPublisher;
        }
    }
}