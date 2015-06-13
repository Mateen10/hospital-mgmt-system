using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_Information_System.Models.Account
{
    public class LoginModel
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private bool rememberMe;
        public bool RememberMe
        {
            get { return rememberMe; }
            set { rememberMe = value; }
        }

    }
}