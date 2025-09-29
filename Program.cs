/*
Một cửa hàng bán thực phẩm bán 3 dạng thực phẩm chính: thực phẩm đông lạnh, thực phẩm tươi sống và thực phẩm khô.
Cả ba loại thực phẩm trên đều có các thuộc tính: tên thực phẩm, xuất xứ, giá, số lượng. 
Riêng với thực phẩm đông lạnh có điều kiện bảo quản (nhiệt độ), thực phẩm tươi sống (có số ngày tối đa sử dụng), thực phẩm khô (có điều kiện bảo quản, ví dụ bảo quản nơi không ẩm mốc)
Xây dựng chương trình cho phép:
- Có sử dụng Singleton design pattern
- Có sử dụng Factory design pattern
- thỏa mãn 5 quan hệ trong phân tích hướng đối tượng (dependency, association, aggregation, composition, generalization/inheritance)
*/
using System;
using System.Text;

namespace Lab8_OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Store sm = Store.GetInstance();

            // Tạo sản phẩm
            Product apple = ProductFactory.CreateProduct("fresh", "P001", "Táo", "Việt Nam", 20000, 100, "7");
            Product rice = ProductFactory.CreateProduct("dried", "P002", "Gạo", "Thái Lan", 15000, 200, "Nơi khô ráo");
            Product fish = ProductFactory.CreateProduct("cold", "P003", "Cá đông lạnh", "Na Uy", 50000, 50, "-18 độ C");

            sm.Warehouse.AddProduct(apple);
            sm.Warehouse.AddProduct(rice);
            sm.Warehouse.AddProduct(fish);
            sm.Warehouse.DisplayProducts();

            // Tạo khách hàng
            Customer c1 = new Customer("C01", "Nguyễn Văn A");
            Customer c2 = new Customer("C02", "Trần Thị B");
            sm.AddCustomer(c1);
            sm.AddCustomer(c2);

            // Tạo đơn hàng
            Order o1 = new Order("O01", c1);
            o1.AddProduct(apple, 50);
            o1.AddProduct(rice, 100);
            sm.AddOrder(o1);

            Order o2 = new Order("O02", c2);
            o2.AddProduct(rice, 80);
            o2.AddProduct(fish, 30);
            sm.AddOrder(o2);

            sm.DisplayOrders();
            Console.WriteLine("\nĐã tạo 2 đơn hàng.");
            Console.WriteLine("________________________");
            Console.Write("Sản phẩm trong kho sau khi tạo đơn:");
            sm.Warehouse.DisplayProducts();

            BehavioralTransaction bt = new BehavioralTransaction();
            bt.AddCustomerProductAssociation(c1, apple);
            bt.AddCustomerProductAssociation(c1, rice);
            bt.AddCustomerProductAssociation(c2, rice);
            bt.AddCustomerProductAssociation(c2, fish);

            // Hiển thị khách hàng mua nhiều sản phẩm
            bt.DisplayCustomerProducts(c1);
            bt.DisplayCustomerProducts(c2);

            // Hiển thị 1 sản phẩm được nhiều khách hàng mua
            bt.DisplayProductCustomers(apple);
            bt.DisplayProductCustomers(rice);
            bt.DisplayProductCustomers(fish);

            Console.WriteLine("________________________");
            // Xóa đơn
            sm.RemoveOrder("O01");
            Console.Write("Sản phẩm trong kho sau khi xóa đơn:");
            sm.Warehouse.DisplayProducts();

            Console.ReadKey();
        }
    }
}