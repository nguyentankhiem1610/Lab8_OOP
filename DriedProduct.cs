using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_OOP2
{
    public class DriedProduct : Product
    {
        public string StorageCondition { get; set; }

        public DriedProduct(string id, string name, string origin, double price, int quantity, string storageCondition)
            : base(id, name, origin, price, quantity)
        {
            StorageCondition = storageCondition;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Dried] {Name} | Xuất xứ: {Origin} | Giá: {Price} | SL: {Quantity} | Bảo quản: {StorageCondition}");
        }
    }

}
