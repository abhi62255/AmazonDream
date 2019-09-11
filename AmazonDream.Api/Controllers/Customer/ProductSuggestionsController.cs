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
    public class ProductSuggestionsController : ControllerBase
    {

        private readonly ProductSuggestion_BLL obj;
        public ProductSuggestionsController(IMapper mapper)
        {
            obj = new ProductSuggestion_BLL(mapper);
        }

        [HttpGet("{id}")]
        public List<ProductModel> GetSuggestedProductsKnownUser(long id)            //for Known user
        {
            return obj.GetSuggestedProductsKnownUser(id);
        }

        [HttpGet]
        public List<ProductModel> GetSuggestedProductsUnknownUser()                 //for Unknown User
        {
            return obj.GetSuggestedProductsUnknownUser();
        }

    }
}
