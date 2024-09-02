using BookAndBorrower.Application.Contract;
using BookAndBorrower.Application.Services;
using BookAndBorrower.Context;
using BookAndBorrower.Infrastructure;
using BookAndBorrower.Model;
using Microsoft.EntityFrameworkCore;

namespace BookAndBorrower
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LibraryContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Db"));
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<IRepository<>>
            builder.Services.AddScoped<IRepository<Book>, Repository<Book>>();
            builder.Services.AddScoped<IRepository<Borrower>, Repository<Borrower>>();
            builder.Services.AddScoped<IRepository<BookBorrower>, Repository<BookBorrower>>();
            builder.Services.AddTransient<IBookService, BookService>();
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
