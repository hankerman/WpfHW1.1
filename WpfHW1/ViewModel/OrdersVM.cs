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
        public List<Order> SelectedOrders { get; set; }
        private string _searchText;
        public string SearchText { get { return _searchText; }
            set { _searchText = value;
                OnPropertyChanged();
            }
        }
        public void UpdateListOrders()
        {
            Orders = UsersDB.Context.Orders.Where(x => _searchText == String.Empty || _searchText == null
                            || (int.TryParse(_searchText, out int id) && x.Id == id)
                            || (x.Client.ToLower().Contains(_searchText.ToLower()))
                            || (DateTime.TryParse(_searchText, out DateTime date) && date == x.Date) 
                            || (x.Products.FirstOrDefault(y => y.Product.Name.ToLower().Contains(_searchText.ToLower())) != null)).ToList();
            OnPropertyChanged("Orders");
            //OnPropertyChanged();
        }
        public void DeleteOrders()
        {
            foreach (var r in SelectedOrders)
            {
                UsersDB.Context.Orders.Remove(r);
            }
            //Orders.RemoveAll(x=>SelectedOrders.Contains(x));
            Orders = UsersDB.Context.Orders.ToList();
            SelectedOrders.Clear();
            //перерисовка можно использовать nameoff(Orders)
            OnPropertyChanged("Orders");
        }
    }
}
