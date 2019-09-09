﻿using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.Models;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class AdminHome_BLL
    {
        ProductDA _productDA = new ProductDA();
        SellerDA _sellerDA = new SellerDA();

        private readonly IMapper _mapper;
        public AdminHome_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ProductModel> GetProduct(string value)          //give all product which are Pending:Accepted:Deleted:All
        {

            var model = new List<ProductModel>();
            var entity = _productDA.GetProductByProductStatus(value);

            foreach (var i in entity)
            {
                model.Add(_mapper.Map<Product, ProductModel>(i));
            }

            return (model);
        }

        public List<SellerModel> GetSeller(string value)          //give all SELLER which are Pending:Accepted:Deleted:All
        {

            var model = new List<SellerModel>();
            var entity = _sellerDA.GetSellerByStatus(value);

            foreach (var i in entity)
            {
                model.Add(_mapper.Map<Seller, SellerModel>(i));
            }

            return (model);
        }

        public Boolean PutSeller(string value,long id)            //Respond to seller Request :Accepted:Deleted
        {
            if (!(value == "Accepted" || value == "Deleted" || value == "accepted" || value == "deleted"))      //check for the if it is valid or not
                return false;

            var entity = _sellerDA.GetSellerByID(id);     //getting the seller by ID

            if(entity != null)
            {
                entity.Status = value;
                _sellerDA.UpdateSeller(entity);       //updating the seller with provided value
                return true;
            }
            return false;



        }

        public Boolean PutProduct(string value, long id)            //Respond to seller Request :Accepted:Deleted
        {
            if (!(value == "Accepted" || value == "Deleted" || value == "accepted" || value == "deleted"))      //check for the "value" if it is valid or not
                return false;

            var entity = _productDA.GetProduct(id);     //getting the Product by ID

            if (entity != null)
            {
                entity.ProductStatus = value;
                _productDA.UpdateProduct(entity);       //updating the Product with provided value
                return true;
            }
            return false;
            
        }

        public List<ProductModel> TrendingProduct()         //Get Trending Product
        {
            var model = new  List<ProductModel>();
            var entity = _productDA.TrendingProduct();

            foreach (var i in entity)
            {
                model.Add(_mapper.Map<Product, ProductModel>(i));
            }

            return model;
        }


        public Boolean TrendResponse(string value,int id)
        {
            if (!(value == "True" || value == "False" || value == "true" || value == "false"))      //check for the "value" if it is valid or not
                return false;

            var entity = _productDA.GetProduct(id);     //getting the Product by ID

            if (entity != null)
            {
                entity.ProductTrend = value;
                _productDA.UpdateProduct(entity);       //updating the Product with provided value
                return true;
            }
            return false;
        }


    }
}
