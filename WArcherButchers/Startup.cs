using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using WArcherButchers.Infrastructure.Serialization;
using WArcherButchers.Infrastructure.Settings;
using WArcherButchers.ServerApp.Infrastructure;
using WArcherButchers.ServerApp.Products;

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

            services.Configure<IConfiguration>(Configuration);
            services.Configure<Auth0Settings>(Configuration.GetSection("Auth0"));
            services.Configure<ServerSettings>(Configuration.GetSection("Server"));
            ConfigureMongo(services);
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

        private void ConfigureMongo(IServiceCollection services)
        {
            ConventionPack conventionPack = new ConventionPack {new CamelCaseElementNameConvention()};
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            services.AddScoped<IMongoClient>(serviceProvider =>
            {
                IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
                string connectionString = configuration.GetConnectionString("Database");
                MongoClient mongoClient = new MongoClient(connectionString);
                return mongoClient;
            });

            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IBsonClassMapper<Product>, ProductBsonClassMapper>();
            services.AddTransient<IBsonClassMapper<Variation>, VariationBsonClassMapper>();
        }
    }
}