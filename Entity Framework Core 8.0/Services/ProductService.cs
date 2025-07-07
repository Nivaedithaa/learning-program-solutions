using EFCoreDemo.Models;
using EFCoreDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Services
{
    class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void GetAll()
        {
            var products = _productRepository.GetAll();
            foreach(var product in products)
            {
                Console.WriteLine(product);
            }
        }
        public void GetById()
        {
            Console.WriteLine("Enter product ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var product = _productRepository.Get(id);
            Console.WriteLine(product);
        }
        public void Add()
        {
            Console.WriteLine("Enter Product name");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter price");
            decimal price = decimal.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Enter category id");
            int categoryId = int.Parse(Console.ReadLine() ?? "0");
            var product = new Product
            {
                Name = name,
                Price = price,
                CategoryId = categoryId

            };
            _productRepository.Add(product);
        }
        public void Update()
        {
            Console.WriteLine("Enter Id");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var product = _productRepository.Get(id);
            product ??= new Product();
            Console.WriteLine("Enter new Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter new Price");
            decimal price = decimal.Parse(Console.ReadLine() ?? "0");
            _productRepository.Update(id, product);
        }
        public void Delete()
        {
            Console.WriteLine("Enter product id");
            int id = int.Parse(Console.ReadLine() ?? "0");
            _productRepository.Delete(id);
        }
    }
}
