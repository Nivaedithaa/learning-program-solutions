using EFCoreDemo.Models;
using EFCoreDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Services
{
    class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void GetAll()
        {
            var categories = _categoryRepository.GetAll();
            foreach(var category in categories)
            {
                Console.WriteLine(category);
            }
        }
        public void GetById()
        {
            Console.WriteLine("enter id");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var category =  _categoryRepository.Get(id);
            Console.WriteLine(category);
        }
        public void Add()
        {
            Console.WriteLine("Enter new Category name");
            string? name =Console.ReadLine();
            var category = new Category
            {
                Name = name
            };
            _categoryRepository.Add(category);
        }
        public void Update()
        {
            Console.WriteLine("enter id");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var category = _categoryRepository.Get(id);
            category ??= new Category();
            Console.WriteLine("Enter new Category");
            var name = Console.ReadLine();
            category.Name = name;
            _categoryRepository.Update(id, category);
        }
        public void Delete()
        {
            Console.WriteLine("enter id");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var category = _categoryRepository.Get(id);
            _categoryRepository.Delete(id);
        }


    }
}
