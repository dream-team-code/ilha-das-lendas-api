using IlhadasLendasAPI.API.Extensions;
using IlhadasLendasAPI.Domain.Core;
using IlhadasLendasAPI.Domain.Core.Notifier;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IlhadasLendasAPI.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //services.AddScoped<IProdutoRepository, ProdutoRepository>();
            //services.AddScoped<IProdutoService, ProdutoService>();
            //services.AddScoped<IProdutoApplication, ProdutoApplication>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<INotificador, Notificador>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}