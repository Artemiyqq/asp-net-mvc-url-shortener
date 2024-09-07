using UrlShortener.Models;
using Microsoft.EntityFrameworkCore;

namespace UrlShortener
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "Redirect",
                pattern: "{shortUrl}",
                defaults: new { controller = "Url", action = "CustomRedirect" }
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Url}/{action=Index}/{id?}");


            using AppDbContext context = new("public");
            var pendingMigrations = context.Database.GetPendingMigrations();
            if (pendingMigrations.Any()) 
                {
                context.Database.Migrate();
            }

            app.Run();
        }
    }
}