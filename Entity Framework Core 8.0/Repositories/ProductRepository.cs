using EFCoreDemo.Data;
using EFCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Repositories
{
    class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(int id, Product updatedProduct)
        {
            var exsitingProduct = Get(id);
            if (exsitingProduct != null)
            {
                exsitingProduct.Name = updatedProduct.Name;
                exsitingProduct.Price = updatedProduct.Price;
                _context.SaveChanges();
                
            }

        }
        public void Delete(int id) 
        { 
            var product = Get(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
