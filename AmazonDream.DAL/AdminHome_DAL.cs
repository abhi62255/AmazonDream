using AmazonDream.Entities;
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
    }
}
