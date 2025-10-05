using System;
using System.Collections.Generic;

namespace Lab8_OOP2
{
    public class WareHouse
    {
        public List<Product> Products { get; private set; }

        public WareHouse()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public Product? FindProduct(string productId)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Id == productId)
                {
                    return Products[i];
                }
            }
            return null;
        }

        public void RestoreProductQuantity(string productId, int quantity)
        {
            Product? found = FindProduct(productId);
            if (found != null)
            {
                found.Quantity += quantity;
            }
            else
            {
                Console.WriteLine($"Không tìm thấy sản phẩm {productId} trong kho để trả lại.");
            }
        }

        public void DisplayProducts()
        {
            Console.WriteLine("\nDanh sách sản phẩm trong kho:");
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{Products[i].Id} - {Products[i].Name} : {Products[i].Quantity} cái");
            }
        }
    }
}
