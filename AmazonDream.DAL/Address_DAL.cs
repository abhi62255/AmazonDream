using AmazonDream.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AmazonDream.DAL
{
    public class Address_DAL
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();

        public Boolean AddAddress(Address entity)           //add Address for Customer:Seller
        {
            db.Address.Add(entity);
            try
            {
                db.SaveChanges();
            }
            catch { return false; }
            return true;
        }

        public List<Address> GetAddressCustomer(long id)            //getting customer address by customer id
        {
            return db.Address.Where(a => a.Customer_ID == id).ToList();
        }
        public List<Address> GetAddressSeller(long id)            //getting Seller address by seller ID
        {
            return db.Address.Where(a => a.Seller_ID == id).ToList();
        }

        public Boolean DeleteAddress(long id)           //Delete Address for Customer:Seller by address ID
        {
            var address = db.Address.Where(a => a.ID == id).FirstOrDefault();
            db.Address.Remove(address);
            try
            {
                db.SaveChanges();
            }
            catch { return false; }
            return true;
        }



    }
}
