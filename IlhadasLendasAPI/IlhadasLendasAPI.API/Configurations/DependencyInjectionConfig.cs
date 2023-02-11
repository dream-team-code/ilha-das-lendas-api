using IlhadasLendasAPI.API.Extensions;
using IlhadasLendasAPI.Application.Applications;
using IlhadasLendasAPI.Application.Interfaces;
using IlhadasLendasAPI.Domain.Core;
using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories;
using IlhadasLendasAPI.Domain.Core.Interfaces.Services;
using IlhadasLendasAPI.Domain.Core.Notifier;
using IlhadasLendasAPI.Domain.Service;
using IlhadasLendasAPI.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IlhadasLendasAPI.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ITimeRepository, TimeRepository>();
            services.AddScoped<ITimeService, TimeService>();
            services.AddScoped<ITimeApplication, TimeApplication>();

            services.AddScoped<IJogadorRepository, JogadorRepository>();
            services.AddScoped<IJogadorService, JogadorService>();
            services.AddScoped<IJogadorApplication, JogadorApplication>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleApplication, RoleApplication>();

            services.AddScoped<INacionalidadeRepository, NacionalidadeRepository>();
            services.AddScoped<INacionalidadeService, NacionalidadeService>();
            services.AddScoped<INacionalidadeApplication, NacionalidadeApplication>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<INotificador, Notificador>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}