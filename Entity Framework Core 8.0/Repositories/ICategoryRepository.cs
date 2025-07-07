using EFCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Repositories
{
    internal interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Get(int id);
        void Add(Category category);
        void Update(int id, Category category);
        void Delete(int id);
    }
}
