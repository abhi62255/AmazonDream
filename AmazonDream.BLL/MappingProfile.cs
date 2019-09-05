using AmazonDream.Entities;
using AmazonDream.Models;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Seller, SellerModel>();
            CreateMap<SellerModel, Seller>();

            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();

            CreateMap<Admin, AdminModel>();
            CreateMap<Admin, AdminModel>();

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();

            CreateMap<ProductPicture, ProductPictureModel>();
            CreateMap<ProductPictureModel, ProductPicture>();




        }
    }
}
