using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_OOP2
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public Customer(string id, string name)
        {
            Id = id;
            Name = name;
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Khách hàng: {Name} (ID: {Id}) - Số đơn hàng: {Orders.Count}");
        }
    }

}
