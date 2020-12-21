using Application.Handlers.Queries;
using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Reflection;

namespace ReferenceService
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
            RegisterRepositories(services);
            services.AddControllers();
            services.AddAutoMapper(typeof(Infrastructure.AutoMapper.AutoMapperProfile).GetTypeInfo().Assembly, typeof(Domain.AutoMapper.AutoMapperProfile).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetGenderQuery).GetTypeInfo().Assembly);
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reference API", Version = "v1" });
            });
            services.AddSingleton<IDatabaseContext, MySQLContext>(provider =>
            {
                return new MySQLContext(Configuration.GetConnectionString("MySQLConnection"));
            });
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reference API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            var infrastructure = Assembly.GetAssembly(typeof(Repository<>));
            var implementationTypes = infrastructure.GetTypes()
                .Where(type => type.GetTypeInfo().ImplementedInterfaces.Any(x => x.Name.EndsWith("Repository")));
            foreach (var implementationType in implementationTypes)
            {
                foreach (var interfaceType in implementationType.GetInterfaces().Where(x => !x.Name.Contains("IRepository")))
                {
                    services.AddTransient(interfaceType, implementationType);
                }
            }
        }
    }
}
