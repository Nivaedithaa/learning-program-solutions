using EFCoreDemo.Data;
using EFCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Repositories
{
    class CategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) 
        {
            _context = context;

        }
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void Update(int id, Category updatedcategory)
        {
            var exsitingCategory = _context.Categories.Find(id);
            if (exsitingCategory != null)
            {
                exsitingCategory.Name=updatedcategory.Name;
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }

        }


    }
}
