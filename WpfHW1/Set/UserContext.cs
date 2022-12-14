using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfHW1.Model;

namespace WpfHW1
{
    internal class UserContext
    {
        private UserContext(User user)
        {
            _user = user;
            _currentUserContext = this;
            OnPropertyChanged("CurrentUserContext");
        }
        private User _user;
        public User User
        {
            get { return _user; } 
        }
        private static UserContext _currentUserContext;
        public static UserContext CurrentUserContext
        {
            get { return _currentUserContext; }
            //set
            //{
            //    if(_currentUserContext == null)
            //    {
            //        _currentUserContext = value;
                    
            //    }
            //}
        }
        public void ClearUser()
        {
            _currentUserContext = null;
        }
        public static void CreateUserContext(User user)
        {
            if(CurrentUserContext != null)
            {
                new UserContext(user);
            }
        }
        //статический NotifyPropertyChanged
        public static event PropertyChangedEventHandler PropertyChanged;
        protected static void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(CurrentUserContext, new PropertyChangedEventArgs(property));
        }
    }
}
