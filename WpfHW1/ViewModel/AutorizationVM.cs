using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHW1.Model;

namespace WpfHW1.ViewModel
{
    internal class AutorizationVM : NotifyClass
    {
        public string LoginUser { get; set; }
        public string PasswordUser { get; set; }
        private string _userName;
        public string UserName { get { return _userName; } 
            set { _userName = value; //OnPropertyChanged("UserName");
                OnPropertyChanged();} }
        public bool Auth()
        {
            if(LoginUser == null) return false;
            if(PasswordUser == null) return false;
            var context = new UsersDB();
            var access = context.Users.Where(x=>x.Login == LoginUser).FirstOrDefault();
            //context.Users.Where(delegate(User x) { return x.Login == CurrentUser.Login; }).FirstOrDefault();
            if(access != null && access.IsAutorization(PasswordUser))
            {
                Global.User = access;
                UserName = access.Name;
                return true;
            }
            return false;
        }
    }
}
