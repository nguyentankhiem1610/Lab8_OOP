using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_OOP2
{
    public abstract class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        protected Product(string id, string name, string origin, double price, int quantity)
        {
            Id = id;
            Name = name;
            Origin = origin;
            Price = price;
            Quantity = quantity;
        }

        public abstract void DisplayInfo();
    }
}
