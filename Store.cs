using System;
using System.Collections.Generic;

namespace Lab8_OOP2
{
    public class Store
    {
        private static Store? instance;
        public WareHouse Warehouse { get; private set; }
        public List<Customer> Customers { get; private set; }
        public List<Order> Orders { get; private set; }
        public BehavioralTransaction BehavioralTransaction { get; private set; }

        private Store()
        {
            Warehouse = new WareHouse();
            Customers = new List<Customer>();
            Orders = new List<Order>();
            BehavioralTransaction = new BehavioralTransaction();
        }

        public static Store GetInstance()
        {
            if (instance == null) instance = new Store();
            return instance;
        }

        public void AddCustomer(Customer c)
        {
            Customers.Add(c);
        }

        public void AddOrder(Order o)
        {
            Orders.Add(o);
            o.Customer.AddOrder(o);
            BehavioralTransaction.RecordOrder(o);
        }
        public void RemoveOrder(string orderId)
        {
            Order? found = null;
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].OrderId == orderId)
                {
                    found = Orders[i];
                    break;
                }
            }

            if (found != null)
            {
                found.RemoveOrder(this);
            }
            else
            {
                Console.WriteLine("Không tìm thấy đơn hàng " + orderId);
            }
        }

        public void DisplayOrders()
        {
            Console.WriteLine("\nDanh sách đơn hàng:");
            for (int i = 0; i < Orders.Count; i++)
                Orders[i].DisplayInfo();
        }
    }
}
