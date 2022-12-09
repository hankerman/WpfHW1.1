using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHW1.Model;

namespace WpfHW1
{
    internal class Global
    {
        private static User _user;
        public static User User
        {
            get { return _user; }
            set { if (value != null) _user = value; }
        }
    }
}
