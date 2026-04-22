using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.Repo.impelementation;
using Canteen_Order_Management_System.Repo.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Canteen_Order_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<My_AppContext>(
                opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("conn"))
                );
            builder.Services.AddScoped<IUser, UserRepo>();
            builder.Services.AddScoped<IFoodItem, FoodItemRepo>();
            builder.Services.AddScoped<IOrder, OrderRepo>();
            builder.Services.AddScoped<IStaff, StaffRepo>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
