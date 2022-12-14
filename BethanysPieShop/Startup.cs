using BethanysPieShop.Models;
using BethanysPieShop.Models.EF;
using BethanysPieShop.Models.Entities;
using BethanysPieShop.Models.Interfaces;
using BethanysPieShop.Models.Mock;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //-- servizi gestiti dall'applicazione
            services.AddScoped<IPieRepository, EFPieRepo>();
            services.AddScoped<ICategoryRepository, EFCategoryRepo>();
            services.AddScoped <IOrderRepository, EFOrderRepo>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));

            services.AddHttpContextAccessor();
            services.AddSession();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //-- middleware components che gestiscono le chiamate http
            if (env.IsDevelopment())
            {
                //permette di usare la pagina delle eccezioni nell'app. => informazioni utili durante lo sviluppo
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            //per gestire file statici(immagini, file css, js)
            app.UseStaticFiles();
            app.UseSession();

            //useRouting e useEndPoints permettono a mvc di rispondere alle richieste http
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
