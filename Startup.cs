using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.DB;
using Clothes_Online_Shop.DB.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Globalization;

namespace Clothes_Online_Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(
            Configuration.GetConnectionString("online_shop")));

            services.AddTransient<IProductsRepository, ProductsDBRepository>();
            services.AddTransient<IImgInfosDBRepository, ImgInfosDBRepository>();
            services.AddTransient<ICartsRepository, CartsDBRepository>();
            services.AddTransient<IFavoriteProductRepository, FavoriteProductDBRepository>();
            services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
            services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
            services.AddSingleton<IUsersManager, UsersManager>();
            services.AddControllersWithViews();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US")
                };
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSerilogRequestLogging();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseRequestLocalization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
