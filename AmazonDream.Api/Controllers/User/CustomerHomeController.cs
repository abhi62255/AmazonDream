using System.Linq;
using AmazonDream.BLL;
using AmazonDream.DAL;
using AmazonDream.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerHomeController : ControllerBase
    {
        private Registration_BLL obj;
        public CustomerHomeController(IMapper mapper)
        {
            obj = new Registration_BLL(mapper);
        }

        public IActionResult Post([FromBody] CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (obj.CustomerRegistration(model))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
