using Application.Abstractions;
using Autofac;
using Autofac.Extras.AggregateService;
using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Linq;
using System.Reflection;
using MediatR.Pipeline;
using API.Interceptor;
using Domain.Interfaces;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using EventBus.Extensions;
using EventBusAzureServiceBus;
using EventBusAzureServiceBus.Extensions;
using Infrastructure.Events;
using MediatR;

namespace RaceService
{

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            InitialiseLogging();
        }

        private void InitialiseLogging()
        {
            var elasticUri = Configuration.GetSection("LogLocation").Value;
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Assembly", Assembly.GetEntryAssembly().GetName().Name)
                .MinimumLevel.Debug()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
                {
                    MinimumLogEventLevel = LogEventLevel.Debug,
                    AutoRegisterTemplate = true
                })
                .CreateLogger();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            AzureServiceBusConnectionDetails connectionDetails = new AzureServiceBusConnectionDetails() { ConnectionString = Configuration.GetConnectionString("AzureServiceBus") };
            services.AddAutoMapper(typeof(Domain.AutoMapper.AutoMapperProfile).GetTypeInfo().Assembly);
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
            
            RegisterEventBus(services, connectionDetails);
            AddEvents(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RACE API", Version = "v1" });
            });
            services.AddSingleton<IDatabaseContext, MySQLContext>(provider =>
            {
                return new MySQLContext(Configuration.GetConnectionString("MySQLConnection"));
            });
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddMediatR(typeof(BaseHandler<,>).GetTypeInfo().Assembly);
            builder
                .RegisterGeneric(typeof(GenericPreProcessorBehavior<>))
                .As(typeof(IRequestPreProcessor<>))
                .InstancePerDependency();
            builder.RegisterGeneric(typeof(EventBusPublisher<>)).As(typeof(INotificationHandler<>));

            builder.RegisterAutoMapper(typeof(Domain.AutoMapper.AutoMapperProfile).GetTypeInfo().Assembly);

            builder.RegisterAggregateService<IAggregateRepository>();
            builder.RegisterAggregateService<ICoreAggregator>();
            builder.RegisterAggregateService<IModelAggregator>();
            // Register your own things directly with Autofac, like:
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Infrastructure)))
                .Where(n => n.Namespace.Contains("Repositories"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RACE API V1");
            });
            ConfigureEventBus(app.ApplicationServices);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureEventBus(IServiceProvider applicationServices)
        {
            applicationServices.ConfigureEventBus();
        }
        private void RegisterEventBus(IServiceCollection serviceCollection, AzureServiceBusConnectionDetails connectionDetails)
        {
            serviceCollection.RegisterEventBus(5);
            serviceCollection.RegisterConnection(connectionDetails, "Auction", "auctionsalechange");
        }

        private void AddEvents(IServiceCollection services)
        {
            var application = Assembly.GetAssembly(typeof(BaseEventHandler<>));
            var integrationEvents = application.GetTypes()
                .Where(type => type.GetTypeInfo().ImplementedInterfaces.Any(x => x.Name.EndsWith("EventHandler") && !type.Name.Contains("Base"))).ToList();

            foreach (var implementationType in integrationEvents)
            {
                foreach (var interfaceType in implementationType.GetInterfaces())
                {
                    services.AddSingleton(interfaceType, implementationType);
                }
            }

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
