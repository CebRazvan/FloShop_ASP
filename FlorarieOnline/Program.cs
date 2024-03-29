using FlorarieOnline.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace FlorarieOnline
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Admin"; // Путь к странице входа
                    options.AccessDeniedPath = "/Account/AccessDenied"; // Путь к странице доступа запрещен
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                // Добавьте другие политики авторизации по необходимости
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Conect DataBase
            var connStrint = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ShopDbContext>(optionsAction => optionsAction.UseSqlite(connStrint));



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            
            app.MapControllerRoute(
                 name: "Admin",
                 pattern: "{area:exists}/{controller=Login}/{action=Index}");

            app.MapControllerRoute(
                 name: "Produs",
                 pattern: "{controller=Produs}/{action=Index}");


            app.Run();
        }
    }
}