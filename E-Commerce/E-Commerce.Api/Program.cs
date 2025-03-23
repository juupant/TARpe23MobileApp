using E_Commerce.Api.Constants;
using E_Commerce.Api.Data;
using E_Commerce.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString(DatabaseConstants.GroceryConnectionStringKey)));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            var mastersGroup = app.MapGroup("/masters").AllowAnonymous();
            mastersGroup.MapGet("/categories", async (DataContext context) =>
                TypedResults.Ok(await context.Categories.AsNoTracking().ToArrayAsync())

            );
            mastersGroup.MapGet("/offers", async (DataContext context) =>
                TypedResults.Ok(await context.Offers.AsNoTracking().ToArrayAsync())

            );
            mastersGroup.MapGet("/popular-products", async (DataContext context, int? count) =>
            {
                if (!count.HasValue || count <= 0)
                {
                    count = 6;
                }
                var randomProducts = await context.Products.AsNoTracking().OrderBy(p => Guid.NewGuid())
                .Take(count.Value).Select(Product.DtoSelector).ToArrayAsync();
                return TypedResults.Ok(randomProducts);
            });

            mastersGroup.MapGet("/categories/{categoryId}/products", async (DataContext context, short categoryId) =>
            {
                var products = await context.Products.Include(p => p.Category).AsNoTracking().Where(p => p.CategoryId == categoryId || p.Category.ParentId == categoryId).Select(Product.DtoSelector).ToArrayAsync();
                return TypedResults.Ok(products);
            });
            app.UseStaticFiles();
            app.Run("https://localhost:12345");
        }
    }
}