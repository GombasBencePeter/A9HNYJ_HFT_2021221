using A9HNYJ_HFT_2021221.Logic;
using A9HNYJ_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace A9HNYJ_HFT_2021221.Endpoint.Controllers
{
    [Route("admin")]
    [ApiController]
    public class AdminController : Controller
    {
        IAdminLogic al;
        public AdminController(IAdminLogic al)
        {
            this.al = al;
        }

        // GET: /book/all
        [HttpGet("book/all")]
        public IEnumerable<Book> GetAllBook()
        {
            return al.GetAllBooks();
        }

        // GET: /publisher/all
        [HttpGet("publisher/all")]
        public IEnumerable<Publisher> GetAlPub()
        {
            return al.GetAllPublishers();
        }

        // GET: /author/all
        [HttpGet("author/all")]
        public IEnumerable<Author> GetAllAut()
        {
            return al.GetAllAuthors();
        }

        // GET /book/{id}
        [HttpGet("book/{id}")]
        public Book Get(int id)
        {
            return al.OneBook(id);
        }

        // POST /book/
        [HttpPost("book")]
        public void PostBook([FromBody] Book value)
        {
            al.AddBook(value);
        }

        // POST /publisher/
        [HttpPost("publisher")]
        public void PostPub([FromBody] Publisher value)
        {
            al.AddPublisher(value);
        }

        // POST /author/
        [HttpPost("author")]
        public void PostAut([FromBody] Author value)
        {
            al.AddAuthor(value);
        }

        // PUT /book/
        [HttpPut("book")]
        public void Put([FromBody] Book value)
        {
             al.UpdateBook(value);
        }

        // PUT /author/
        [HttpPut("author")]
        public void Put([FromBody] Author value)
        {
            al.UpdateAuthor(value);
        }

        // GET: /book/all
        [HttpGet("book/booksWithLessThanTen")]
        public IEnumerable<ListBooksWithLessThan10PcsReturnValue> GetBooksWithLessThan10Pcs()
        {
            return al.ListBooksWithLessThan10PcsWith10DayDelivery();
        }

            // PUT /publisher/
            [HttpPut("publisher")]
        public void Put([FromBody] Publisher value)
        {
            al.UpdatePublisher(value);
        }

        // DELETE /book/5
        [HttpDelete("book/{id}")]
        public void DeleteBook(int id)
        {
            al.DeleteBook(id);
        }

        // DELETE /book/5
        [HttpDelete("publisher/{id}")]
        public void DeletePublisher(int id)
        {
            al.DeletePublisher(id);
        }
        
        // DELETE /book/5
        [HttpDelete("author/{id}")]
        public void DeleteAuthor(int id)
        {
            al.DeleteAuthor(id);
        }
    }
}
