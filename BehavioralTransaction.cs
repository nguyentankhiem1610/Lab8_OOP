using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_OOP2
{
    public class BehavioralTransaction
    {
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        private Dictionary<Customer, List<Product>> CustomerProducts; 

        public BehavioralTransaction()
        {
            Customers = new List<Customer>();
            Products = new List<Product>();
            CustomerProducts = new Dictionary<Customer, List<Product>>();
        }

        public void AddCustomerProductAssociation(Customer customer, Product product)
        {
            if (!Customers.Contains(customer))
                Customers.Add(customer);

            if (!Products.Contains(product))
                Products.Add(product);

            if (!CustomerProducts.ContainsKey(customer))
                CustomerProducts[customer] = new List<Product>();

            CustomerProducts[customer].Add(product);
        }
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

        public void RebuildMappings(List<Order> orders)
        {
            Customers.Clear();
            Products.Clear();
            CustomerProducts.Clear();

            for (int i = 0; i < orders.Count; i++)
            {
                RecordOrder(orders[i]);
            }
        }

        // Hiển thị khách hàng mua nhiều sản phẩm
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

        // Hiển thị một sản phẩm được nhiều khách hàng mua
        public void DisplayProductCustomers(Product product)
        {
            Console.WriteLine($"\nSản phẩm '{product.Name}' được mua bởi:");
            foreach (KeyValuePair<Customer, List<Product>> entry in CustomerProducts)
            {
                if (entry.Value.Contains(product))
                {
                    Console.WriteLine($"- {entry.Key.Name}");
                }
            }
        }
    }

}
