using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfHW1
{
    internal class PageContext : NotifyClass
    {
        private Stack<UserControl> _pages = new Stack<UserControl>();
        public UserControl CurrentPage { get; private set; }
        public void AddPage(UserControl page)
        {
            _pages.Push(page);
            CurrentPage = page;
            OnPropertyChanged("CurrentPage");
        }
        public void DropPage()
        {
            _pages.Pop();
            CurrentPage = _pages.Peek();
            OnPropertyChanged("CurrentPage");
        }
        public void NextPage(UserControl page)
        {
            DropPage();
            AddPage(page);
        }
        //переобновление страницы
        public void RefreshPage(params object[] parametrs)
        {
            Type typePage = CurrentPage.GetType();
            CurrentPage = (UserControl)Activator.CreateInstance(typePage, parametrs);
        }
        public void ChangeRootPage(UserControl page)
        {
            _pages.Clear();
            AddPage(page);
        }
    }
}
