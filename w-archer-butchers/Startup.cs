using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            services.Configure<IConfiguration>(Configuration)
                .Configure<Auth0Settings>(Configuration.GetSection("Auth0"))
                .Configure<ServerSettings>(Configuration.GetSection("Server"))
                .AddSingleton<IEntityTypeConfigurationFactory, EntityTypeConfigurationFactory>()
                .AddScoped<DbContext>(s => s.GetService<IWArcherDbContextFactory>().CreateDbContext())
                .AddTypesFromAssembly<EntityTypeConfigurationFactory>("Repository")
                .And("Mapper")
                .And("Factory")
                .And("Query")
                .And("Service");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new {controller = "Home", action = "Index"});
            });
        }
    }
}