﻿using AmazonDream.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace AmazonDream.DAL
{
    public class Registration_DAL
    {
        private readonly AmazonDreamDbContext db;

        public Registration_DAL()
        {
            db = new AmazonDreamDbContext();
        }
   


        public Boolean SellerRegistration(Seller model)
        { 
            db.Seller.Add(model);
            db.SaveChanges();
            return true;
        }
        public Boolean CustomerRegistration(Customer model)
        {
            db.Customer.Add(model);
            db.SaveChanges();
            return true;
        }

        public Boolean EmailExistance( string email)
        {
            if(db.Admin.Where(e => e.Email == email).FirstOrDefault() == null)
            {
                if(db.Seller.Where(e => e.Email == email).FirstOrDefault() == null)
                {
                    if (db.Customer.Where(e => e.Email == email).FirstOrDefault() == null)
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }
}