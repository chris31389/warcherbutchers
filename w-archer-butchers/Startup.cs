using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WArcherButchers.Infrastructure.Serialization;
using WArcherButchers.Infrastructure.Settings;
using WArcherButchers.ServerApp.Infrastructure.Data.DbContexts;
using WArcherButchers.ServerApp.Infrastructure.DependencyInjection;

namespace WArcherButchers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions(options => JsonCustomSerializer.Setup(options.SerializerSettings));

            services
                .Configure<IConfiguration>(Configuration)
                .Configure<Auth0Settings>(Configuration.GetSection("Auth0"))
                .Configure<ServerSettings>(Configuration.GetSection("Server"))
                .AddSingleton<IEntityTypeConfigurationFactory, EntityTypeConfigurationFactory>()
//                .AddScoped<DbContext>(s => s.GetService<IWArcherDbContextFactory>().CreateDbContext())
                .AddTypesFromAssembly<EntityTypeConfigurationFactory>("Repository")
                .And("Mapper")
                .And("Factory")
                .And("Query")
                .And("Service")
                .ServiceCollection
                .AddDbContext<WArcherDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Database")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            if (env.IsDevelopment())
            {
                loggerFactory.AddDebug();
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html"));
            });
        }
    }
}