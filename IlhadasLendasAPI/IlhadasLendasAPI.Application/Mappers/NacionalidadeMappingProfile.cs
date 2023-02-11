using AutoMapper;
using IlhadasLendasAPI.Application.Dtos.Nacionalidade;
using IlhadasLendasAPI.Domain.Entities;

namespace IlhadasLendasAPI.Application.Mappers
{
    public class NacionalidadeMappingProfile : Profile
    {
        public NacionalidadeMappingProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Nacionalidade, ViewNacionalidadeDto>().ReverseMap();
            CreateMap<Nacionalidade, PutNacionalidadeDto>().ReverseMap();
            CreateMap<Nacionalidade, PostNacionalidadeDto>().ReverseMap();
        }
    }
}