using Microsoft.EntityFrameworkCore;
using TEST.WEB.API.Data;
using TEST.WEB.API.Extensions;
using TEST.WEB.API.Models;

namespace TEST.WEB.API.Endpoints
{
    public static class Products
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            // Get all products with their Category
            app.MapGet("/products", async (AppDbContext db) =>
            {
                var products = await db.Products
                    .Include(p => p.Category)   // <-- include Category!
                    .ToListAsync();

                return Results.Ok(products);
            });

            // Get product by ID with its Category
            app.MapGet("/products/{id}", async (int id, AppDbContext db) =>
            {
                var product = await db.Products
                    .Include(p => p.Category)   // <-- include Category!
                    .FirstOrDefaultAsync(p => p.Id == id);

                return product is null ? Results.NotFound() : Results.Ok(product);
            });

            // Get distinct Id and Name
            app.MapGet("/products/distinct", async (AppDbContext db) =>
            {
                var distinctProducts = await db.Products
                    .Select(p => new { p.Id, p.Name })
                    .Distinct()
                    .ToListAsync();

                return Results.Ok(distinctProducts);
            });
        }
    }
}
