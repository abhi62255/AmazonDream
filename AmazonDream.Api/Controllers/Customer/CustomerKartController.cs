﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AmazonDream.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerKartController : ControllerBase
    {
        private CustomerHome_BLL obj;

        public CustomerKartController(IMapper mapper)
        {
            obj = new CustomerHome_BLL(mapper);
        }



        

        // POST: api/CustomerKart/add
        [HttpPost("add")]
        public IActionResult Post([FromBody] KartModel model)           //Adding product to kart
        {
            if(obj.AddToKart(model))
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/CustomerKart/Increse
        [HttpPut("Increse/{id}")]
        public IActionResult PutIncreseKartQuantity(long id)
        {
            if(obj.IncreseKartQuantity(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/CustomerKart/Decrese
        [HttpPut("Decrese/{id}")]
        public IActionResult PutDecreseKartQuantity(long id)
        {
            if (obj.DecreseKartQuantity(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/CustomerKart/RemoveItem
        [HttpPut("RemoveItem/{id}")]                                        //Remove One item from Kart
        public IActionResult PutRemoveKartItem(long id)
        {
            if (obj.RemoveKartItem(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/CustomerKart/Remove
        [HttpPut("Remove/{id}")]                                        //Clear KArt for customer by customer ID
        public IActionResult PutRemoveKart(long id)
        {
            if (obj.RemoveKart(id))
            {
                return Ok();
            }
            return BadRequest();
        }


    }
}
