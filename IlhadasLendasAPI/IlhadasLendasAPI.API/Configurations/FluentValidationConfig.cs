using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Text.Json.Serialization;

namespace IlhadasLendasAPI.API.Configurations
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(config =>
                {
                    config.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    config.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(conf =>
                {
                    conf.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddFluentValidationAutoValidation();

            //services.AddValidatorsFromAssemblyContaining<PostProdutoDto>();
            //services.AddValidatorsFromAssemblyContaining<PutProdutoDto>();

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            services.AddFluentValidationRulesToSwagger();
        }
    }
}