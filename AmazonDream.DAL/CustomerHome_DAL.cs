using AmazonDream.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class CustomerHome_DAL
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();

        public Product GetProduct(long id)              //getting product by ID
        {
            return db.Product.Where(p => p.ID == id).FirstOrDefault();
        }



        public Boolean AddToKart(Kart entity,Product product)               //Adding product to kart
        {
            db.Entry(product).State = EntityState.Modified;
            db.Kart.Add(entity);
            try
            {
                db.SaveChanges();
            }
            catch { return false; } 
            return true;
        }

        public Kart GetKart(long id)                //Get Kart value by Kart ID
        {
            return db.Kart.Where(k => k.ID == id).FirstOrDefault();
        }

        public List<Kart> GetCustomerKart(long id)                //Get Kart For a customer by customer ID
        {
            return db.Kart.Where(k => k.Customer_ID == id).ToList();
        }


        public Boolean UpdateKart(Kart entity)                //UpdateKart
        {
            db.Entry(entity).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch { return false; }
            return true;
        }

        public Boolean RemoveKartItem(long id)          //remove one row from Kart
        {
            db.Kart.Remove(GetKart(id));
            try
            {
                db.SaveChanges();
            }
            catch { return false; }
            return true;
        }
        public Boolean RemoveKart(long id)          //remove Whole Kart for a customer
        {
            var entity = GetCustomerKart(id);
            foreach(var kartItem in entity)
            {
                db.Kart.Remove(kartItem);

            }
            try
            {
                db.SaveChanges();
            }
            catch { return false; }
            return true;
        }

    }
}
