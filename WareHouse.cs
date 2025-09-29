using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_OOP2
{

    public class WareHouse
    {
        public List<Product> Products { get; set; }

        public WareHouse()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product p)
        {
            Products.Add(p);
        }

        public void DisplayProducts()
        {
            Console.WriteLine("\n Danh sách sản phẩm trong kho:");
            for (int i = 0; i < Products.Count; i++)
            {
                Products[i].DisplayInfo();
            }
        }
    }

}
