using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHW1.Model;

namespace WpfHW1.ViewModel
{
    internal class OrdersVM : NotifyClass
    {
        public OrdersVM()
        {
            Orders = UsersDB.Context.Orders.ToList();
        }
        public List<Order> Orders { get; set; }
        private string _searchText;
        public string SearchText { get { return _searchText; }
            set { _searchText = value;
                int id;
                Orders = UsersDB.Context.Orders.Where(x=>(int.TryParse(_searchText, out id) && x.Id == id) || _searchText ==String.Empty).ToList();
                OnPropertyChanged("Orders");
                OnPropertyChanged(); } }
    }
}
