using Microsoft.EntityFrameworkCore;
using TEST.WEB.API.Data;
using TEST.WEB.API.Extensions;
using TEST.WEB.API.Models;

namespace TEST.WEB.API.Endpoints
{
    public static class Categories
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            // Get all categories
            app.MapGet("/categories", async (AppDbContext db) =>
            {
                var categories = await db.Categories.ToListAsync();
                return Results.Ok(categories);
            });

            // Get product by ID
            app.MapGet("/categories/{id}", async (int id, AppDbContext db) =>
            {
                var product = await db.Categories.FindAsync(id);
                return product is null ? Results.NotFound() : Results.Ok(product);
            });

            // Get distinct Id and Name
            app.MapGet("/categories/distinct", async (AppDbContext db) =>
            {
                var distinctCategories = await db.Categories
                    .Select(p => new { p.Id, p.Name })
                    .Distinct()
                    .ToListAsync();

                return Results.Ok(distinctCategories);
            });
        }
    }
}
