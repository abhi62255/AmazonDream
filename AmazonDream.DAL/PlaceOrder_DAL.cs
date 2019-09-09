using AmazonDream.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class PlaceOrder_DAL
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();

        public Boolean PlaceOrder(List<PlacedOrder> entity)
        {

            foreach(var order in entity)
            {
                db.PlacedOrder.Add(order);
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
            return true;
        
        }

        public Boolean RemoveKartItem(long id)
        {
            db.Kart.Remove(db.Kart.Where(k => k.ID == id).FirstOrDefault());
            return true;
        }

        public List<Kart> GetKart(long id)              //Getting Kart by customer ID
        {
            return db.Kart.Where(k => k.Customer_ID == id).ToList();
        }

        public Product GetProduct(long id)              //Getting Product by product ID
        {
            return db.Product.Where(k => k.ID == id).FirstOrDefault();
        }
            
        public Address GetAddress(long id)              //getting Address by address ID
        {
            return db.Address.Where(a => a.ID == id).FirstOrDefault();
        }
        public long GetOrderNumber()
        {
            return db.PlacedOrder.OrderByDescending(o => o.ID).Select(o => o.OrderNumber).FirstOrDefault();
        }



    }
}
