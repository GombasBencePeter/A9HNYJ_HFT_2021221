using A9HNYJ_HFT_2021221.Logic;
using A9HNYJ_HFT_2021221.Models;
using A9HNYJ_HFT_2021221.Endpoint.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace A9HNYJ_HFT_2021221.Endpoint.Controllers
{
    [Route("admin")]
    [ApiController]
    public class AdminController : Controller
    {
        IAdminLogic al;
        IHubContext<SignalRHub> hub;
        public AdminController(IAdminLogic al, IHubContext<SignalRHub> hub)
        {
            this.al = al;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("BookCreated", value);
        }

        // POST /publisher/
        [HttpPost("Publisher")]
        public void PostPub([FromBody] Publisher value)
        {
            al.AddPublisher(value);
            this.hub.Clients.All.SendAsync("PublisherCreated", value);

        }

        // POST /author/
        [HttpPost("Author")]
        public void PostAut([FromBody] Author value)
        {
            al.AddAuthor(value);
            this.hub.Clients.All.SendAsync("AuthorCreated", value);

        }

        // PUT /book/
        [HttpPut("Book")]
        public void Put([FromBody] Book value)
        {
             al.UpdateBook(value);
            this.hub.Clients.All.SendAsync("BookUpdated", value);

        }

        // PUT /author/
        [HttpPut("Author")]
        public void Put([FromBody] Author value)
        {
            al.UpdateAuthor(value);
            this.hub.Clients.All.SendAsync("AuthorUpdated", value);

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
            this.hub.Clients.All.SendAsync("PublisherUpdated", value);

        }

        // DELETE /book/5
        [HttpDelete("Book/{id}")]
        public void DeleteBook(int id)
        {
            var bookToDelete = al.OneBook(id);
            al.DeleteBook(id);
            this.hub.Clients.All.SendAsync("BookDeleted", bookToDelete);

        }

        // DELETE /book/5
        [HttpDelete("Publisher/{id}")]
        public void DeletePublisher(int id)
        {
            var publisherToDelete = al.OnePublisher(id);
            al.DeletePublisher(id);
            this.hub.Clients.All.SendAsync("PublisherDeleted", publisherToDelete);

        }

        // DELETE /book/5
        [HttpDelete("Author/{id}")]
        public void DeleteAuthor(int id)
        {
            var authorToDelete = al.OneAuthor(id);
            al.DeleteAuthor(id);
            this.hub.Clients.All.SendAsync("AuthorDeleted", authorToDelete);

        }
    }
}
