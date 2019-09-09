﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class CommonDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();

        public Boolean EmailExistance(string email)            //Checking if email is already registered or not
        {
            if (db.Admin.Where(e => e.Email == email).FirstOrDefault() == null)
            {
                if (db.Seller.Where(e => e.Email == email).FirstOrDefault() == null)
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
