using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AutoMapperWrapper.Extensions
{
    public static class ExtensionMethods 
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
