using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSearchFunction
{
    public class Product
    {
        public int PID {  get; set; }
        public string PName { get; set; }
        public string Category { get; set; }

        public Product(int id, string name, string category)
        {
            PID = id;
            PName = name;
            Category = category;

        }
        public override string ToString()
        { 
        return $"ID : {PID}, Name : {PName}, Category : {Category}";
        }
    }
}
