using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A9HNYJ_HFT_2021221.Models;


namespace A9HNYJ_HFT_2021221.Repository
{
    /// <summary>
    /// Generic repository class for common repository functions.
    /// </summary>
    /// <typeparam name="T"> Book, Publisher or Author.</typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Common db context.
        /// </summary>
        protected DbContext Context { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context"> Common Db context.</param>
        public Repository(DbContext context)
        {
            this.Context = context;
            this.Context?.SaveChanges();
        }

        /// <summary>
        /// Adds item to context. <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="o"> Object to add.</param>
        public T AddItem(object o)
        {
            if (o is T)
            {
                var p = o as T;
                this.Context.Add(p);
                this.Context.SaveChanges();
                return p;
            }

            return null;
        }

        /// <summary>
        /// Deletes one item and saves changes.
        /// </summary>
        /// <param name="index"> Index of item to delete. </param>
        public void DeleteOne(int index)
        {
            object item = this.GetOne(index);
            if (item != null)
            {
                this.Context.Remove(item);
                this.Context.SaveChanges();
            }
        }

        /// <summary>
        /// Gives back collection of all items in one table containing T items.
        /// </summary>
        /// <returns> Collection of T items. Full table. </returns>
        public IQueryable<T> GetAll()
        {
            return this.Context.Set<T>();
        }

        /// <summary>
        /// Gives back one item from one table containint T items.
        /// </summary>
        /// <param name="index"> Index of item to return. </param>
        /// <returns>T item with index specified from table containitn T items. </returns>
        public T GetOne(int index)
        {
            return this.Context.Find<T>(index);
        }
    }
}
