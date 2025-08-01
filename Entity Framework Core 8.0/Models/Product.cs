﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public override string ToString()
        {
            return $"Product ID: {Id}, Name: {Name}, Price: {Price}, " +
                $"Category ID: {CategoryId}, Category Name: {Category?.Name}";
        }

    }
}
