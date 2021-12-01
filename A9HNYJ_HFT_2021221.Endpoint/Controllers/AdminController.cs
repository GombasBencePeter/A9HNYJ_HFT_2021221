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

        // GET: /admin/allbooks
        [HttpGet("allbooks")]
        public IEnumerable<Book> Get()
        {
            return al.GetAllBooks();
        }

        // GET /admin/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return al.OneBook(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Book value)
        {
            
        }

        // DELETE /books/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            al.DeleteBook(id);
        }
    }
}
