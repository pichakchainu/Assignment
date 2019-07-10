using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;
using WebAPI.Infrastructure.EF;
using WebAPI.Ioc;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<AssignmentDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Assignment API", Version = "v1" });
            });

            return this.ConfigureIoC(services);
        }

        public virtual IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();
            container.Configure(config =>
            {
                config.AddRegistry(new StructureMapRegistry());
                config.Populate(services);
            });
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IContainer container)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assignment API V1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var assignmentDbContext = container.GetInstance<AssignmentDbContext>();
                 if (!assignmentDbContext.Database.CanConnect())
                {
                    assignmentDbContext.Database.Migrate();
                    assignmentDbContext.EnsureSeeded();
                }
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
