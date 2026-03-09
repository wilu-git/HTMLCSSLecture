using HTMLCSSLecture.Models.Database;
using HTMLCSSLecture.Repositories.Users;
using HTMLCSSLecture.Services.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
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
                //Get Connection string from the dbcontext
                options.UseSqlServer(builder.Configuration.GetConnectionString("RegistrationSystem"));
                //to remove the string and put it directly in the program instead of getting connection string
                //options.UseSqlServer("Server=EA611-13;Database=RegistrationSystem;Trusted_Connection=true;TrustServerCertificate=true");

            });
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {         
                    options.LoginPath = "/Accounts/Login";
                    options.AccessDeniedPath = "/Accounts/AccessDenied";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.SlidingExpiration = true;

                    /* Given path 
                    https://localhost:7112/Accounts/Login?ReturnUrl=%2FHome%2FLogin */

                    //TODO: Secured Controllers 
                });
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

            app.UseAuthentication();
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
