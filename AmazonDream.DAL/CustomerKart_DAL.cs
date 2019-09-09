using AmazonDream.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class CustomerKart_DAL
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();

        public Product GetProduct(long id)              //getting product by ID
        {
            return db.Product.Where(p => p.ID == id).FirstOrDefault();
        }
        public Boolean UpdateProduct(Product product)               //Update Product : Changin ProductInKart Column 
        {
            db.Entry(product).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch { return false; }
            return true;
        }


        public Boolean AddToKart(Kart entity,Product product)               //Adding product to kart
        {
            if(UpdateProduct(product))
            {
                db.Kart.Add(entity);
                try
                {
                    db.SaveChanges();
                }
                catch { return false; }
                return true;
            }
            return false;
            
        }

        public Kart GetKart(long id)                //Get Kart value by Kart ID
        {
            return db.Kart.Where(k => k.ID == id).FirstOrDefault();
        }

        public List<Kart> GetCustomerKart(long id)                //Get Kart For a customer by customer ID
        {
            return db.Kart.Where(k => k.Customer_ID == id).ToList();
        }


        public Boolean UpdateKart(Kart entity,Product product)                //UpdateKart
        {
            if (UpdateProduct(product))
            {
                db.Entry(entity).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch { return false; }
                return true;
            }
            return false;
        }

        public Boolean RemoveKartItem(long id,Product product)          //remove one row from Kart
        {
            if (UpdateProduct(product))
            {
                db.Kart.Remove(GetKart(id));
                try
                {
                    db.SaveChanges();
                }
                catch { return false; }
                return true;
            }
            return false;
        }

        public Boolean RemoveKart(long id,List<Product> products)          //remove Whole Kart for a customer
        {
            var entity = GetCustomerKart(id);
            foreach (var pro in products)               //update all products INkart value
            {
                if (UpdateProduct(pro) == false)
                    return false;
                
            }
            foreach(var kartItem in entity)             //removing product from kart
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
