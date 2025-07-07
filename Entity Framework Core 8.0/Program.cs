using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using EFCoreDemo.Repositories;
using EFCoreDemo.Services;
using EFCoreDemo.Models;

internal class Program
{
    private static async Task Main(string[] args) // ✅ Make Main async
    {
        var host = Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((context, config) =>
             {
                 config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
             })
             .ConfigureServices((context, services) =>
             {
                 var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                 services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));
                 services.AddScoped<IProductRepository, ProductRepository>();
                 services.AddScoped<ICategoryRepository, CategoryRepository>();
                 services.AddScoped<CategoryService>();
                 services.AddScoped<ProductService>();
             })
             .Build();

        
        using var scope = host.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        
        /*context.Products.RemoveRange(context.Products);
        context.Categories.RemoveRange(context.Categories);
        await context.SaveChangesAsync();

        
        var electronics = new Category { Name = "Electronics" };
        var groceries = new Category { Name = "Groceries" };
        await context.Categories.AddRangeAsync(electronics, groceries);

        
        var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
        var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
        await context.Products.AddRangeAsync(product1, product2);

        
        await context.SaveChangesAsync();

        Console.WriteLine(" Lab 4 data inserted successfully.");*/

        /*Console.WriteLine("\n=== Lab 5: Retrieving Data ===");

        var products = await context.Products.ToListAsync();
        Console.WriteLine("All Products:");
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - ₹{p.Price}");

        var product = await context.Products.FindAsync(1);
        Console.WriteLine($"Found by ID: {product?.Name}");

        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Expensive Product: {expensive?.Name}");*/


        // === Lab 6: Updating and Deleting Records ===

        // 1. Update a Product
        /*var productToUpdate = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
        if (productToUpdate != null)
        {
            productToUpdate.Price = 70000;
            await context.SaveChangesAsync();
            Console.WriteLine($"Updated '{productToUpdate.Name}' price to ₹{productToUpdate.Price}");
        }
        else
        {
            Console.WriteLine("Product 'Laptop' not found to update.");
        }

        // 2. Delete a Product
        var productToDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
        if (productToDelete != null)
        {
            context.Products.Remove(productToDelete);
            await context.SaveChangesAsync();
            Console.WriteLine($"Deleted product: {productToDelete.Name}");
        }
        else
        {
            Console.WriteLine("Product 'Rice Bag' not found to delete.");
        }*/
        // === Lab 7: Writing Queries with LINQ ===

        // 1. Filter and Sort products with price > 1000, descending
        var filtered = await context.Products
            .Where(p => p.Price > 1000)
            .OrderByDescending(p => p.Price)
            .ToListAsync();

        Console.WriteLine("\nFiltered and Sorted Products (Price > 1000):");
        foreach (var p in filtered)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price}");
        }

        // 2. Project into anonymous DTOs
        var productDTOs = await context.Products
            .Select(p => new { p.Name, p.Price })
            .ToListAsync();

        Console.WriteLine("\nProduct DTOs (Name & Price):");
        foreach (var dto in productDTOs)
        {
            Console.WriteLine($"Product: {dto.Name}, Price: ₹{dto.Price}");
        }


    }
}
