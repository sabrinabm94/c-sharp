using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebApp.Models;
using MyWebApp.Repository;

namespace MyWebApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnection = _configuration.GetConnectionString("MyWebAppDb");
            services.AddDbContext<Context>(options =>
            options.UseMySql(sqlConnection, b => b.MigrationsAssembly("MyWebApp")));

            services.AddMvc();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IMoneyBillRepository, MoneyBillRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
