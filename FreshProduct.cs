using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab8_OOP2
{

    public class FreshProduct : Product
    {
        public int ExpiryDays { get; set; }

        public FreshProduct(string id, string name, string origin, double price, int quantity, int expiryDays)
            : base(id, name, origin, price, quantity)
        {
            ExpiryDays = expiryDays;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Fresh] {Name} | Xuất xứ: {Origin} | Giá: {Price} | SL: {Quantity} | HSD: {ExpiryDays} ngày");
        }
    }

}
