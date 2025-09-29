using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_OOP2
{
    public class ProductFactory
    {
        public static Product CreateProduct(string type, string id, string name, string origin, double price, int quantity, object extra)
        {
            if (type.ToLower() == "cold")
            {
                return new ColdProduct(id, name, origin, price, quantity, (string)extra);
            }
            else if (type.ToLower() == "fresh")
            {
                return new FreshProduct(id, name, origin, price, quantity, Convert.ToInt32(extra));
            }
            else if (type.ToLower() == "dried")
            {
                return new DriedProduct(id, name, origin, price, quantity, (string)extra);
            }
            else
                throw new Exception("Loại sản phẩm không hợp lệ!");
        }
    }

}
