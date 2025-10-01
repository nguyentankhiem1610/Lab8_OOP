using System;
using System.Collections.Generic;

namespace Lab8_OOP2
{
    public class Order
    {
        public string OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> Details { get; set; }

        public Order(string orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer;
            Details = new List<OrderDetail>();
        }

        public void AddProduct(Product product, int quantity)
        {
            Details.Add(new OrderDetail(product, quantity));
            product.Quantity -= quantity; // trừ hàng trong kho
        }

        public void RemoveAllDetails()
        {
            Details.Clear(); // Composition: xoá chi tiết khi xoá đơn
        }

        public double GetTotal()
        {
            double total = 0;
            for (int i = 0; i < Details.Count; i++)
            {
                total += Details[i].GetTotal();
            }
            return total;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Đơn hàng {OrderId} của {Customer.Name}");
            for (int i = 0; i < Details.Count; i++)
            {
                Details[i].DisplayInfo();
            }
            Console.WriteLine($"Tổng tiền: {GetTotal()}");
        }
    }
}
