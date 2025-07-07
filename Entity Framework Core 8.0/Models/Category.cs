using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List <Product> Products{ get; set; }
        public override string ToString()
        {
            return $"Category ID: {Id}, Name: {Name}";
        }
    }
}
