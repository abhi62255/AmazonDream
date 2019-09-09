using AmazonDream.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.DAL
{
    public class PlaceOrder_DAL
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();

        public Boolean PlaceOrder(PlacedOrder entity)
        {
            db.PlacedOrder.Add(entity);
            db.SaveChanges();
            //try
            //{
            //    db.SaveChanges();
            //    return true;
            //}
            //catch { return false; }
            return true;
           

        }



    }
}
