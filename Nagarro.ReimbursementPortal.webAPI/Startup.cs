using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Nagarro.ReimbursementPortal.webAPI.Data;
using Nagarro.ReimbursementPortal.webAPI.Data.Uow;
using Nagarro.ReimbursementPortal.webAPI.Interfaces.IUow;
using Nagarro.ReimbursementPortal.webAPI.Mapper;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System.Net;

namespace Nagarro.ReimbursementPortal.webAPI
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
           
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            services.AddControllers();


            services.AddCors();

            //for inMemory database
            services.AddDbContext<DataContext>(option => option.UseInMemoryDatabase("mydb"));

            //db context connection for ssms
            //services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            //db context connection for mySQL
            //services.AddDbContext<DataContext>(options => options.UseMySql(Configuration.GetConnectionString("Default")));

            //var connectionString = Configuration.GetConnectionString("Default");
            //services.AddDbContext<DataContext>(options =>
            //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(AutomapperProfiles).Assembly);

            ConfigureSwagger(services);

        }

        //Swagger configuration method
        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "CatalogService",
                        Version = "v1"
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(
                    options =>
                    {
                        options.Run(
                            async context =>
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                var ex = context.Features.Get<IExceptionHandlerFeature>();
                                if(ex != null)
                                {
                                    await context.Response.WriteAsync(ex.Error.Message);
                                }
                            });
                    });
            }
      

            app.UseRouting();

            app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
