using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class AdminHome_BLL
    {
        AdminHome_DAL obj = new AdminHome_DAL();

        private readonly IMapper _mapper;
        public AdminHome_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ProductModel> GetProduct(string value)          //give all product which are Pending:Accepted:Deleted
        {

            var model = new List<ProductModel>();
            var entity = obj.GetProduct(value);

            foreach (var i in entity)
            {
                model.Add(_mapper.Map<Product, ProductModel>(i));
            }

            return (model);
        }


    }
}
