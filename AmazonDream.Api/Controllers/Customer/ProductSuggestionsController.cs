using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSuggestionsController : ControllerBase
    {

        private readonly Wishlist_BLL obj;
        public ProductSuggestionsController(IMapper mapper)
        {
            obj = new ProductSuggestion_BLL(mapper);
        }




    }
}
