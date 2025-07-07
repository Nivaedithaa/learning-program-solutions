using EFCoreDemo;
using EFCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Repositories
{
    interface IProductRepository
    {
        List<Product> GetAll();
        Product Get(int id);
        void Add(Product product);
        void Update(int id,Product product);
        void Delete(int id);
    }
}
