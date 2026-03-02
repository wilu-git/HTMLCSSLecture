using HTMLCSSLecture.Models.Database;
using HTMLCSSLecture.Repositories.Users;
using HTMLCSSLecture.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace HTMLCSSLecture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<RegistrationSystemContext> (options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("RegistrationSystem"));
            });
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Registration}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
