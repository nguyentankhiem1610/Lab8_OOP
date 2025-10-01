using System;
using System.Collections.Generic;

namespace Lab8_OOP2
{
    public class Store
    {
        private static Store instance;
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
            Order found = null;
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
                // Trả sản phẩm về kho
                for (int i = 0; i < found.Details.Count; i++)
                {
                    Product product = found.Details[i].Product;
                    int quantity = found.Details[i].Quantity;

                    // Tìm trong kho sản phẩm tương ứng
                    Product productInWarehouse = null;
                    for (int j = 0; j < Warehouse.Products.Count; j++)
                    {
                        if (Warehouse.Products[j].Id == product.Id)
                        {
                            productInWarehouse = Warehouse.Products[j];
                            break;
                        }
                    }

                    if (productInWarehouse != null)
                    {
                        productInWarehouse.Quantity += quantity; // trả về kho
                    }
                }

                // Xóa hết chi tiết đơn hàng (Composition)
                found.RemoveAllDetails();
                // Xóa đơn hàng khỏi danh sách
                Orders.Remove(found);

                // Cập nhật lại mapping hành vi
                BehavioralTransaction.RebuildMappings(Orders);

                Console.WriteLine("Đã xóa đơn " + orderId + " và trả sản phẩm về kho.");
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
