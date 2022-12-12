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
        
        private string _userName;
        public string UserName { get { return _userName; } 
            set { _userName = value; //OnPropertyChanged("UserName");
                OnPropertyChanged();} }
        private string _message;
        public string Message { get { return _message; }
            set { _message = value; OnPropertyChanged(); } }
        
        const int FAIL_COUNT = 3;  //Колличество неудачных попыток
        const int PAUSE = 10;  // Количество секунд блокировки авторизации

        private int _failCount;
        public int FailCount { get { return _failCount; }
            set {
                if(value > 0)
                {
                    _failCount = value;                    
                    Message = $"Колличество неудачных попыток {_failCount}";
                }
                else
                {
                    var t = StartPause();
                    _failCount = FAIL_COUNT;
                }
            }
        }
        private bool _isEnabledAuth;
        public bool IsEnabledAuth { get { return _isEnabledAuth; }
                                    set { _isEnabledAuth = value; OnPropertyChanged(); }
        }
        public AutorizationVM()
        {
            Message = $"У вас осталось {FailCount} попыток";
            IsEnabledAuth = true;
            FailCount = FAIL_COUNT;
            //OnPropertyChanged("FailCount");
        }
        public bool Auth(string password)
        {
            if(LoginUser == null) return false;
            if(password == null) return false;
            var context = new UsersDB();
            var access = context.Users.Where(x=>x.Login == LoginUser).FirstOrDefault();
            //context.Users.Where(delegate(User x) { return x.Login == CurrentUser.Login; }).FirstOrDefault();
            if(access != null && access.IsAutorization(password))
            {
                Global.User = access;
                UserName = access.Name;
                return true;
            }
            FailCount--;
            return false;
        }
        private async Task StartPause()
        {
            IsEnabledAuth = false;
            for (int i = PAUSE; i > 0; i--)
            {
                Message = $"Авторизация заблокирована на {i} секунд";
                await Task.Delay(1000);
            }
            //OnPropertyChanged(Message);
            IsEnabledAuth = true;
            Message = "Повторите попытку";
        }
    }
}
