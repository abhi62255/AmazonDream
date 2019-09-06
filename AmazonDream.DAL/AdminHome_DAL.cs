using AmazonDream.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class AdminHome_DAL
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();

        public List<Product> GetProduct(string value)           //give all product which are Pending:Accepted:Deleted
        {
            var entity = new List<Product>();
            value = value.ToLower();
            if (value == "all")
            {
                entity = db.Product.Where(o => o.ProductStatus != "Deleted").ToList();
                return entity;
            }

            entity = db.Product.Where(o => o.ProductStatus == value).ToList();
            return entity;
        }


        public List<Seller> GetSeller(string value)           //give all SELLER which are Pending:Accepted:Deleted:All
        {
            var entity = new List<Seller>();
            value = value.ToLower();
            if (value == "all")
            {
                entity = db.Seller.Where(o => o.Status != "Deleted").ToList();
                return entity;
            }

            entity = db.Seller.Where(o => o.Status == value).ToList();
            return entity;
        }
        public Seller GetSellerByID(long id)            //give seller by ID
        {
            return db.Seller.Where(s => s.ID == id).FirstOrDefault();
        }

        public Boolean UpdateSeller(Seller entity)      //Update SELLER
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return true;

        }


        public Product GetProductByID(long id)            //give Product by ID
        {
            return db.Product.Where(s => s.ID == id).FirstOrDefault();
        }

        public Boolean UpdateProduct(Product entity)      //Update PRODUCT
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public List<Product> TrendingProduct()              //Get Trending Product
        {
            return db.Product.Where(p => p.ProductTrend == "True").ToList();
        }
    }
}
