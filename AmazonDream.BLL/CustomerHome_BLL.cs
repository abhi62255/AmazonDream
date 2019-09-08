using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class CustomerHome_BLL
    {
        CustomerHome_DAL obj = new CustomerHome_DAL();

        private readonly IMapper _mapper;
        public CustomerHome_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Boolean AddToKart(KartModel model)           //Adding product to kart
        {
            var productEntity = ProductAvailability(model.Product_ID, model.Quantity);
            if (productEntity != null)                                                          //Checking Product Availability
            {
                    productEntity.ProductQuantityInKart += model.Quantity;

                    var entity = _mapper.Map<KartModel, Kart>(model);
                    entity.DateTime = DateTime.Now;

                    if (obj.AddToKart(entity, productEntity))
                    {
                        return true;
                    }
                    return false;

            }
            return false;
        }

        public Product ProductAvailability(long id, int quantity)               //Checking Product Availability
        {
            var productEntity = obj.GetProduct(id);       //checking if product exists
            if (productEntity != null)
            {
                var availableQuantity = productEntity.ProductQuantity - productEntity.ProductQuantityInKart;
                if (availableQuantity >= quantity)             //checking if the required quantity is available or not 
                {
                    return productEntity;
                }
            }
            return null;
        }

        public Boolean IncreseKartQuantity(long id)         //Incresing Quantity By One
        {
            var kart = obj.GetKart(id);
            if (kart != null)
            {
                kart.Quantity += 1;
                if (obj.UpdateKart(kart))
                    return true;
            }
            return false;
        }
        public Boolean DecreseKartQuantity(long id)             //Decresing Quantity By One
        {
            var kart = obj.GetKart(id);
            if (kart != null)
            {
                kart.Quantity -= 1;
                if (obj.UpdateKart(kart))
                    return true;
            }
            return false;
        }

        public Boolean RemoveKartItem(long id)              //Remove One item from Kart
        {
            if (obj.RemoveKartItem(id))
                return true;
            return false;
        }

        public Boolean RemoveKart(long id)              //Clear KArt for customer by customer ID
        {
            if (obj.RemoveKart(id))
                return true;
            return false;
        }






    }
}
