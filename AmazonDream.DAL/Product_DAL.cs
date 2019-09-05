using AmazonDream.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AmazonDream.DAL
{
    public class Product_DAL
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();
        public Boolean AddProduct(Product entity)
        {
            db.Product.Add(entity);
            db.SaveChanges();
            return true;

        }
        public Boolean AddProductPicture(ProductPicture entity)
        {
            db.ProductPicture.Add(entity);
            try { db.SaveChanges(); }
            catch { return false; }
           
            return true;

        }
        public Boolean DeleteProduct(Product entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            try { db.SaveChanges(); }
            catch { return false; }
            return true;

        }

        public Product GetProduct(long id)
        {
            return (db.Product.Where(p => p.ID == id).FirstOrDefault());
        }
        public List<Product> GetProductsAll(long id)
        {
            return (db.Product.Where(p => p.Seller_ID == id).ToList());
        }
        public List<Product> GetProductsPending(long id)
        {
            return (db.Product.Where(p => p.Seller_ID == id && p.ProductStatus =="Pending").ToList());
        }
        public List<Product> GetProductsActive(long id)
        {
            return (db.Product.Where(p => p.Seller_ID == id && p.ProductStatus == "Active").ToList());
        }
    }
}
