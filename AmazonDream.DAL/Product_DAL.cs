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

        public Boolean AddProduct(Product entity)       //add Product 
        {
            db.Product.Add(entity);
            db.SaveChanges();
            return true;

        }


        public Boolean AddProductPicture(ProductPicture entity)     //add Product Picture
        {
            db.ProductPicture.Add(entity);
            try { db.SaveChanges(); }
            catch { return false; }
           
            return true;

        }
        public Boolean UpdateProduct(Product entity)        //Update Product
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return true;

        }


        public Boolean DeleteProduct(Product entity)        //Soft Delete Product
        {
            db.Entry(entity).State = EntityState.Modified;
            try { db.SaveChanges(); }
            catch { return false; }
            return true;

        }

        public Product GetProduct(long id)          //get Product by Product ID
        {
            return (db.Product.Where(p => p.ID == id).FirstOrDefault());
        }
        public List<Product> GetProductsAll(long id)        //get all product by seller ID
        {
            return (db.Product.Where(p => p.Seller_ID == id && p.ProductStatus != "Deleted").ToList());
        }
        public List<Product> GetProductsPending(long id)        //get Pending product by seller ID
        {
            return (db.Product.Where(p => p.Seller_ID == id && p.ProductStatus =="Pending").ToList());
        }
        public List<Product> GetProductsActive(long id)         //get Active product by seller ID
        {
            return (db.Product.Where(p => p.Seller_ID == id && p.ProductStatus == "Active").ToList());
        }
        public List<Product> GetProductsTrending(string value,long id)         //get Trending or non trending product by seller ID
        {
            return (db.Product.Where(p => p.Seller_ID == id && p.ProductTrend == value).ToList());
        }
    }
}
