using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class PlaceOrder_BLL
    {
        PlaceOrder_DAL obj = new PlaceOrder_DAL();

        private readonly IMapper _mapper;
        public PlaceOrder_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }


        public Boolean PlaceOrder(PlacedOrderModel model)
        {
            var entity = _mapper.Map<PlacedOrderModel, PlacedOrder>(model);

        }



    }
}
