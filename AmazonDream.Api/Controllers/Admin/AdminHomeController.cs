using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AmazonDream.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminHomeController : ControllerBase
    {

        private AdminHome_BLL obj;

        public AdminHomeController(IMapper mapper)
        {
            obj = new AdminHome_BLL(mapper);
        }










        // GET: api/AdminHome/Pending:Accepted:Deleted
        [HttpGet("Product/{value}")]
        public List<ProductModel> Get(string value)             //give all product which are Pending:Accepted:Deleted
        {

            return obj.GetProduct(value);
        }

        // GET: api/AdminHome/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AdminHome
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AdminHome/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
