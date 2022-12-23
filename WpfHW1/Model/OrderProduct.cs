﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHW1.Model
{
    public class OrderProduct : NotifyClass
    {
        public Product Product { get; set; }
        private int _quantity;
        public int Quantity { get => _quantity;
            set {
                _quantity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Price));
            } 
        }
        public decimal Price => Product.Price * Quantity;
    }
}
