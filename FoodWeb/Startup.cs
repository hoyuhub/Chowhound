using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using FoodDal;
using Models;
using log4net;
using System.Configuration;
using System.IO;
using log4net.Repository;
using log4net.Config;

namespace FoodWeb
{
    public class Startup
    {

        public static ILoggerRepository repository { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //  services.AddHangfire(r => r.UseSqlServerStorage(@"Data Source=169.254.244.73;Initial Catalog=HangFire;User ID=sa;Password=Server@2017"));
            services.AddMvc();
            services.Configure<IISOptions>(Options =>
            {
                Options.ForwardClientCertificate = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //  app.UseHangfireServer();
            //app.UseHangfireDashboard();
            //每天定时更新当天天气
            //    RecurringJob.AddOrUpdate(() => new Common.Weather().WeatherUpdate(new Address().GetXCity("中国地级市")), Cron.Daily);
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
