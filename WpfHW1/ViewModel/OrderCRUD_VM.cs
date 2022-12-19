using System;
using System.Collections.Generic;
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
            if(order == null)
            {
                _currentOrder = new Order();
            }
            else
            {
                _currentOrder = order;
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
    }
}
