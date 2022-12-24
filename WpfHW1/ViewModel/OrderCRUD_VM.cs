using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHW1.Model;

namespace WpfHW1.ViewModel
{
    internal class OrderCRUD_VM : NotifyClass
    {
        public OrderCRUD_VM(Order order = null)
        {
            _currentOrder = new Order();
            if (order != null)
            {
                _currentOrder.Products = new ObservableCollection<OrderProduct>(order.Products);
                _currentOrder.Client = order.Client;
                _currentOrder.Date = order.Date;
                _currentOrder.Id = order.Id;
                
            }
            
        }
        private Order _currentOrder;
        public Order CurrentOrder
        {
            get
            {
                return _currentOrder;
                //get => _currentOrder
            }
            private set { _currentOrder = value; }
        }
        public int Id {
            get 
            {
                return _currentOrder.Id;
            }
            set 
            {
                _currentOrder.Id = value;
                OnPropertyChanged();
            } 
        }
        public string Client
        {
            get
            {
                return _currentOrder.Client;
            }
            set
            {
                _currentOrder.Client = value;
                OnPropertyChanged();
            }
        }
        public DateTime Date
        {
            get
            {
                return _currentOrder.Date;
            }
            set
            {
                _currentOrder.Date = value;
            }
        }
        public decimal Price => _currentOrder.Price;
        public ObservableCollection<OrderProduct> Products
        {
            get
            {
                return _currentOrder.Products;
            }
            set
            {
                _currentOrder.Products = value;
                OnPropertyChanged();
            }
        }
        private OrderProduct _selectProduct;
        public OrderProduct SelectProduct {
            get
            {
                return _selectProduct;
            }
            set
            {
                _selectProduct = value;
                OnPropertyChanged();
            }
        }
        public void AddProduct(Product product)
        {
            var s = Products.FirstOrDefault(x=>x.Product.ID== product.ID);
            if(s!=null)
            {
                s.Quantity++;
                return;
            }
            Products.Add(new OrderProduct() { Product = product, Quantity = 1 });
            OnPropertyChanged(nameof(Price));
        }
        public void DeleteProduct()
        {
            Products.Remove(SelectProduct);
            OnPropertyChanged(nameof(Price));
        }
    }
}
