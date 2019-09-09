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
            var orders = new List<PlacedOrder>();
            var modelK = obj.GetKart(model.Customer_ID);

            var orderNumber = obj.GetOrderNumber();     //Creating Order number
            if (orderNumber == 0)
                orderNumber = 999;
            orderNumber += 1;

            var modelA = obj.GetAddress(model.Address_ID);      //Creating Address
            string address = "Address Line : " + modelA.AddressLine + " City : " + modelA.City + " State : " + modelA.State +
                              " Postal Code : " + modelA.PostalCode + " Address Type : " + modelA.AddressType;

            foreach (var k in modelK)
            {

                //common start
                var order = new PlacedOrder();
                order.Customer_ID = model.Customer_ID;
                order.PaymentType = model.PaymentType;
                
                order.Address = address;
                order.DateTime = DateTime.Now;
                order.Status = "Order Placed";
                
                order.OrderNumber = orderNumber;
                //common finish


                var product = obj.GetProduct(k.Product_ID);
                order.Quantity = k.Quantity;
                var ActualPrice = product.ProductPrice - (product.ProductPrice * product.ProductDiscount) / 100;

                order.Amount = k.Quantity * ActualPrice;
                order.Product_ID = k.Product_ID;
                obj.RemoveKartItem(k.ID);           //but not releasing Item IN Kart value
                orders.Add(order);
            }
            if(obj.PlaceOrder(orders))
                return true;
            return false;
        }



    }
}
