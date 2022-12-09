﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHW1.Model
{
    internal class User
    {
        public string Name { get; private set; }
        public string Login { get; private set; }
        string Password { get; set; }
        public User(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }
        public bool IsAutorization(string password) => password == Password;
        //{
        //     if(password == Password)
        //    {
        //        return true;
        //    }
        //     return false;
        //}
    }
}
