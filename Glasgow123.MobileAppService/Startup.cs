using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

using Glasgow123.Models;
using Glasgow123.MobileAppService.Models;
using Glasgow123.MobileAppService.Models.Repositories;
using Newtonsoft.Json;

namespace Glasgow123.MobileAppService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options => {
                 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            services.AddDbContext<SQLItemContext>();
            services.AddSingleton<IModelRepository<UniversityClass>, UniversityClassRepository>();
            services.AddSingleton<IModelRepository<Person>, PersonRepository>();
            services.AddSingleton<IModelRepository<Feedback>, FeedbackRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Glasgow123 Backend",
                    Description = "Your Glasgow123 app will connect here too get all its data!",
                    Contact = new Contact
                    {
                        Name = "Team 404",
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.Run(async (context) => await Task.Run(() => context.Response.Redirect("/swagger")));
        }
    }
}
