using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AmazonDream.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization.Json;

namespace AmazonDream.Api.Controllers.Seller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerProductController : ControllerBase
    {

        private SellerProduct_BLL obj;
        public SellerProductController(IMapper mapper)
        {
            obj = new SellerProduct_BLL(mapper);
        }


        // GET: api/SellerProduct/1
        [HttpGet("{id}")]
        public ProductModel GetProduct(long id)       //ProductID
        {
            return obj.GetProduct(id);
        }

        // GET: api/SellerProduct/all/1
        [HttpGet("all/{id}")]
        public List<ProductModel> GetProductsAll(long id)       //Get product by sellerID
        { 
            return obj.GetProductsAll(id);
        }

        // GET: api/SellerProduct/pending/1
        [HttpGet("Pending/{id}")]
        public List<ProductModel> GetProductsPending(long id)       //Get product by sellerID
        {
            return obj.GetProductsPending(id);
        }

        // GET: api/SellerProduct/active/1
        [HttpGet("Active/{id}")]
        public List<ProductModel> GetProductsActive(long id)       //Get product by sellerID
        {
            return obj.GetProductsActive(id);
        }




        // POST: api/SellerProduct/product
        [HttpPost("product")]
        public IActionResult PostProduct([FromBody] ProductModel model)        //add product
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (obj.AddProduct(model))
            {
                return Ok();
            }
            return BadRequest();
        }
        // POST: api/SellerProduct/productPicture
        [HttpPost("productPicture")]
        public IActionResult PostProductPicture([FromBody] ProductPictureModel model)        //add product Picture
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (obj.AddProductPicture(model))
            {
                return Ok();
            }
            return BadRequest();
        }

        // POST: api/SellerProduct/delete/1
        [HttpPatch("delete/{id}")]
        public IActionResult DeleteProduct(long id)
        {
            if (obj.DeleteProduct(id))
            {
                return Ok();
            }
            return BadRequest();
        }


    }
}
