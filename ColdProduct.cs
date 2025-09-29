using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_OOP2
{
    public class ColdProduct : Product
    {
        public string StorageTemperature { get; set; }

        public ColdProduct(string id, string name, string origin, double price, int quantity, string temperature)
            : base(id, name, origin, price, quantity)
        {
            StorageTemperature = temperature;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Cold] {Name} | Xuất xứ: {Origin} | Giá: {Price} | SL: {Quantity} | Bảo quản: {StorageTemperature}");
        }
    }

}
