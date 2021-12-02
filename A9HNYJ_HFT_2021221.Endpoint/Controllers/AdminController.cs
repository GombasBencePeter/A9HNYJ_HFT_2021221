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
        public IEnumerable<Book> Get()
        {
            return al.GetAllBooks();
        }

        // GET /book/{id}
        [HttpGet("book/{id}")]
        public Book Get(int id)
        {
            return al.OneBook(id);
        }

        // POST /book/
        [HttpPost("book")]
        public void Post([FromBody] Book value)
        {
            al.AddBook(value);
        }

        // PUT /book/
        [HttpPut("book")]
        public void Put([FromBody] Book value)
        {

            try{
                al.UpdateBook(value);
            }catch(Exception e)
            {
                
            }
            
        }

        // PUT /author/
        [HttpPut("author")]
        public void Put([FromBody] Author value)
        {
            if (value.AuthorKey is int)
            {
                al.UpdateAuthor(value);
            }
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
            if (value.PublisherID is int)
            {
                al.UpdatePublisher(value);
            }
        }

        // DELETE /book/5
        [HttpDelete("book/{id}")]
        public void Delete(int id)
        {
            al.DeleteBook(id);
        }
    }
}
