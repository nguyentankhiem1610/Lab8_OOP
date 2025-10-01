using System;

namespace Lab8_OOP2
{
    public class OrderDetail
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderDetail(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public double GetTotal()
        {
            return Product.Price * Quantity;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"   {Product.Name} | SL: {Quantity} | Thành tiền: {GetTotal()}");
        }
    }
}
