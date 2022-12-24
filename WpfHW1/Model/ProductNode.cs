﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHW1.Model
{
    public class ProductNode : INode
    {
        public ProductNode(Product p)
        {
            Product = p;
        }
        public string Name { get => Product.Name; }
        public Product Product { get; private set; }
        
    }
}
