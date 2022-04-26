using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Test_Colleague.Data;
using Test_Colleague.IRepository;
using Test_Colleague.Models;
using Test_Colleague.Repository;

namespace Test_Colleague
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddControllers();

            services.AddScoped<IMessageServices, MessagesServices>();


            services.AddMvc();

            services.AddDbContext<DB_COLLEAGUEContext>(options => options
            .UseSqlServer(Configuration
            .GetConnectionString("DefaultConnection")));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");

                endpoints.MapControllers();


                endpoints.MapHub<MessageCenterHub>("/messageCenterHub");
            });
        }
    }
}
