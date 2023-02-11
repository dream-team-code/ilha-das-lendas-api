using IlhadasLendasAPI.Application.Mappers;

namespace IlhadasLendasAPI.API.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
               typeof(TimeMappingProfile),
               typeof(JogadorMappingProfile),
               typeof(RoleMappingProfile),
               typeof(NacionalidadeMappingProfile));
        }
    }
}