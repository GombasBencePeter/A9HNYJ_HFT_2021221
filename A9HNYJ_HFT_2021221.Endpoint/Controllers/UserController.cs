using A9HNYJ_HFT_2021221.Logic;
using A9HNYJ_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace A9HNYJ_HFT_2021221.Endpoint.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        IUserLogic ul;
        public UserController(IUserLogic ul)
        {
            this.ul = ul;
        }

        // GET: /book/all
        [HttpGet("listauthorseditions")]
        public IEnumerable<ListAllAuthorsEditionsReturnValue> ListAuthorsEditions()
        {
            return ul.ListAllAuthorsHowManyEditions();
        }

        // GET: /book/forkids
        [HttpGet("book/forkids")]
        public IEnumerable<Book> GetAllBooksforkids()
        {
            return ul.ListEnglishBookForKids();
        }

        // GET: /book/withneweditions
        [HttpGet("book/withneweditions")]
        public IEnumerable<Book> GetBooksWithNewEditions()
        {
            return ul.ListNewBooksWithOldEditions();
        }

        /// ////////////////

        // GET: /book/all
        [HttpGet("book/all")]
        public IEnumerable<Book> GetAllBooks()
        {
            return ul.GetAllBooks();
        }

        // GET: /publisher/all
        [HttpGet("publisher/all")]
        public IEnumerable<Publisher> GetAllPublishers()
        {
            return ul.GetAllPublishers();
        }

        // GET: /author/all
        [HttpGet("author/all")]
        public IEnumerable<Author> GetAllAuthors()
        {
            return ul.GetAllAuthors();
        }

        /// ////////////////////////////////////
        
        // GET /book/{id}
        [HttpGet("book/{id}")]
        public Book GetBook(int id)
        {
            return ul.OneBook(id);
        }

        // GET /publisher/{id}
        [HttpGet("publisher/{id}")]
        public Publisher GetPub(int id)
        {
            return ul.OnePublisher(id);
        }

        // GET /author/{id}
        [HttpGet("author/{id}")]
        public Author GetAuthor(int id)
        {
            return ul.OneAuthor(id);
        }


    }
}
