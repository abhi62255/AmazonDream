using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class SellerProduct_BLL
    {
        Product_DAL obj = new Product_DAL();

        private readonly IMapper _mapper;
        public SellerProduct_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Boolean AddProduct(ProductModel model)
        {
            var entity = _mapper.Map<ProductModel, Product>(model);
            entity.ProductStatus = "Pending";

            if(obj.AddProduct(entity))
            {
                return true;
            }
            return false;

        }

        public Boolean AddProductPicture(ProductPictureModel model)
        {
            var entity = _mapper.Map<ProductPictureModel, ProductPicture>(model);

            if (obj.AddProductPicture(entity))
            {
                return true;
            }
            return false;

        }
        public Boolean DeleteProduct(long id)           //to soft delete product
        {
            var model = obj.GetProduct(id);
            if (model != null)
            {
                model.ProductStatus = "Deleted";
                if(obj.DeleteProduct(model))
                {
                    return true;
                }
                return false;

            }
            else
            {
                return false;
            }
        }


        public ProductModel GetProduct(long id)
        {
            var entity = _mapper.Map<Product,ProductModel>(obj.GetProduct(id));
            return (entity);

        }

        public List<ProductModel> GetProductsAll(long id)
        {
            var model = new List<ProductModel>();
            var entity = obj.GetProductsAll(id);
            foreach(var i in entity)
            {
                model.Add(_mapper.Map<Product, ProductModel>(i));
            }

            return (model);
             
            

        }
        public List<ProductModel> GetProductsPending(long id)
        {
            var model = new List<ProductModel>();
            var entity = obj.GetProductsPending(id);
            foreach (var i in entity)
            {
                model.Add(_mapper.Map<Product, ProductModel>(i));
            }

            return (model);



        }
        public List<ProductModel> GetProductsActive(long id)
        {
            var model = new List<ProductModel>();
            var entity = obj.GetProductsActive(id);
            foreach (var i in entity)
            {
                model.Add(_mapper.Map<Product, ProductModel>(i));
            }

            return (model);



        }

    }
}
