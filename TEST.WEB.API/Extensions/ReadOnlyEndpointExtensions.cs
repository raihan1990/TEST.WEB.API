using Microsoft.EntityFrameworkCore;
using TEST.WEB.API.Data;
using TEST.WEB.API.Models;

namespace TEST.WEB.API.Extensions
{
    public static class ReadOnlyEndpointExtensions
    {
        public static void MapReadOnlyEndpoints<TEntity>(this WebApplication app, string routeBase)
        where TEntity : class, IEntity
        {
            // Get all products
            app.MapGet($"/{routeBase}", async (AppDbContext db) =>
                await db.Set<TEntity>().ToListAsync());

            // Get product by ID
            app.MapGet($"/{routeBase}/{{id}}", async (int id, AppDbContext db) =>
            {
                var entity = await db.Set<TEntity>().FindAsync(id);
                return entity is null ? Results.NotFound() : Results.Ok(entity);
            });

            // Get distinct Id and Name
            app.MapGet($"/{routeBase}/distinct", async (AppDbContext db) =>
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
