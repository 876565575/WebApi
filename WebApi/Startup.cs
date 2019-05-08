using System.IO;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApi.Filter;
using WebApi.Service;
using WebApi.utils;

namespace WebApi
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        private string name;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _logger = logger;
            Configuration = configuration;
            var repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(option =>
            {
                option.Filters.Add(typeof(PermissionRequiredAttribute));
                option.Filters.Add(typeof(HttpGlobalExceptionFilter));
            });
            services.AddScoped<IUserService, UserService>();
            // 配置日志
            services.AddLogging(logConfig => {
                //log4net.Config.XmlConfigurator.Configure(Common.Logger.LoggerRepository);
                Logger.LoadLogger();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}