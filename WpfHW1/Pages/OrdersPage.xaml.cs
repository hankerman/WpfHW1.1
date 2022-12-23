using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfHW1.Model;
using WpfHW1.ViewModel;

namespace WpfHW1.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : UserControl
    {
        private OrdersVM _vm;
        public OrdersPage()
        {
            InitializeComponent();
            _vm = new OrdersVM();
            this.DataContext = _vm;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            _vm.UpdateListOrders();
        }

        private void DeliteOrders_Click(object sender, RoutedEventArgs e)
        {
            _vm.SelectedOrders = OrdersLV.SelectedItems.Cast<Order>().ToList();
            _vm.DeleteOrders();
        }

        private void ModifyOrder_Click(object sender, RoutedEventArgs e)
        {
            _vm.SelectedOrders = OrdersLV.SelectedItems.Cast<Order>().ToList();
            Order order = _vm.SelectedOrders.FirstOrDefault();
            if(order != null)
            {
                var page = new OrderCRUD(order);
                PageContext.CurrentPageContext.AddPage(page);
            }
            

        }
    }
}
