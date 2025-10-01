using System;
using System.Collections.Generic;

namespace Lab8_OOP2
{
    public class BehavioralTransaction
    {
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }

        private Dictionary<Customer, List<Product>> CustomerProducts;
        private Dictionary<Product, List<Customer>> ProductCustomers;

        public BehavioralTransaction()
        {
            Customers = new List<Customer>();
            Products = new List<Product>();
            CustomerProducts = new Dictionary<Customer, List<Product>>();
            ProductCustomers = new Dictionary<Product, List<Customer>>();
        }

        // Association: quan hệ 2 chiều giữa Customer và Product
        public void AddCustomerProductAssociation(Customer customer, Product product)
        {
            if (!Customers.Contains(customer))
                Customers.Add(customer);
            if (!Products.Contains(product))
                Products.Add(product);

            if (!CustomerProducts.ContainsKey(customer))
                CustomerProducts[customer] = new List<Product>();
            CustomerProducts[customer].Add(product);

            if (!ProductCustomers.ContainsKey(product))
                ProductCustomers[product] = new List<Customer>();
            if (!ProductCustomers[product].Contains(customer))
                ProductCustomers[product].Add(customer);
        }

        // Ghi nhận đơn hàng
        public void RecordOrder(Order order)
        {
            Customer customer = order.Customer;
            for (int i = 0; i < order.Details.Count; i++)
            {
                Product product = order.Details[i].Product;
                int quantity = order.Details[i].Quantity;
                for (int j = 0; j < quantity; j++)
                {
                    AddCustomerProductAssociation(customer, product);
                }
            }
        }

        // Xây dựng lại mapping từ danh sách đơn hàng
        public void RebuildMappings(List<Order> orders)
        {
            Customers.Clear();
            Products.Clear();
            CustomerProducts.Clear();
            ProductCustomers.Clear();

            for (int i = 0; i < orders.Count; i++)
            {
                RecordOrder(orders[i]);
            }
        }

        public void DisplayCustomerProducts(Customer customer)
        {
            if (CustomerProducts.ContainsKey(customer))
            {
                Console.WriteLine($"\nKhách hàng '{customer.Name}' đã mua:");
                foreach (Product product in CustomerProducts[customer])
                {
                    Console.WriteLine($"- {product.Name}");
                }
            }
        }

        public void DisplayProductCustomers(Product product)
        {
            if (ProductCustomers.ContainsKey(product))
            {
                Console.WriteLine($"\nSản phẩm '{product.Name}' được mua bởi:");
                foreach (Customer customer in ProductCustomers[product])
                {
                    Console.WriteLine($"- {customer.Name}");
                }
            }
        }
    }
}
