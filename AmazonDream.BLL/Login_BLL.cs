using AmazonDream.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class Login_BLL
    {
        CommonDA _commonDA = new CommonDA();

        public string login(string email,string password)
        {
            return _commonDA.login(email, password);
        }
    }
}
