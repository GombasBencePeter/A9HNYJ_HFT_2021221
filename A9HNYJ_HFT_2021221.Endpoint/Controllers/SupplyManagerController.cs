using A9HNYJ_HFT_2021221.Logic;
using A9HNYJ_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace A9HNYJ_HFT_2021221.Endpoint.Controllers
{
    [Route("supplymanager")]
    [ApiController]
    public class SupplyManagerController : Controller
    {
        ISupplyManager sm;
        public SupplyManagerController(ISupplyManager sm)
        {
            this.sm = sm;
        }



        // PUT /publisher/
        [HttpPut("book/addsupply/{id}-{value}")]
        public void AddSupply( int id, int value)
        {
            sm.AddSupply(id, value);
        }

        // PUT /publisher/
        [HttpPut("book/changeprice/{id}-{value}")]
        public void ChangePrice(int id, int value)
        {
            sm.ChangePrice(id, value);
        }

        // PUT /publisher/
        [HttpPut("book/changesupply/{id}-{value}")]
        public void ChangeSupply(int id, int value)
        {
            sm.ChangeSupply(id, value);
        }
    }
}
