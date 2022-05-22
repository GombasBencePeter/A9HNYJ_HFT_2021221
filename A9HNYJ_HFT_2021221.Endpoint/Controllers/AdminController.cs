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
        [HttpGet("Book")]
        public IEnumerable<Book> GetAllBook()
        {
            return al.GetAllBooks();
        }

        // GET: /publisher/all
        [HttpGet("Publisher")]
        public IEnumerable<Publisher> GetAlPub()
        {
            return al.GetAllPublishers();
        }

        // GET: /author/all
        [HttpGet("Author")]
        public IEnumerable<Author> GetAllAut()
        {
            return al.GetAllAuthors();
        }

        // GET /book/{id}
        [HttpGet("Book/{id}")]
        public Book Get(int id)
        {
            return al.OneBook(id);
        }

        // POST /book/
        [HttpPost("Book")]
        public void PostBook([FromBody] Book value)
        {
            al.AddBook(value);
        }

        // POST /publisher/
        [HttpPost("Publisher")]
        public void PostPub([FromBody] Publisher value)
        {
            al.AddPublisher(value);
        }

        // POST /author/
        [HttpPost("Author")]
        public void PostAut([FromBody] Author value)
        {
            al.AddAuthor(value);
        }

        // PUT /book/
        [HttpPut("Book")]
        public void Put([FromBody] Book value)
        {
             al.UpdateBook(value);
        }

        // PUT /author/
        [HttpPut("Author")]
        public void Put([FromBody] Author value)
        {
            al.UpdateAuthor(value);
        }

        // GET: /book/all
        [HttpGet("Book/booksWithLessThanTen")]
        public IEnumerable<ListBooksWithLessThan10PcsReturnValue> GetBooksWithLessThan10Pcs()
        {
            return al.ListBooksWithLessThan10PcsWith10DayDelivery();
        }

            // PUT /publisher/
            [HttpPut("Publisher")]
        public void Put([FromBody] Publisher value)
        {
            al.UpdatePublisher(value);
        }

        // DELETE /book/5
        [HttpDelete("Book/{id}")]
        public void DeleteBook(int id)
        {
            al.DeleteBook(id);
        }

        // DELETE /book/5
        [HttpDelete("Publisher/{id}")]
        public void DeletePublisher(int id)
        {
            al.DeletePublisher(id);
        }
        
        // DELETE /book/5
        [HttpDelete("Author/{id}")]
        public void DeleteAuthor(int id)
        {
            al.DeleteAuthor(id);
        }
    }
}
