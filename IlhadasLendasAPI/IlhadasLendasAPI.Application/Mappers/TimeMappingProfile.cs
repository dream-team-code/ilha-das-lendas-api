using AutoMapper;
using IlhadasLendasAPI.Application.Dtos.Jogador;
using IlhadasLendasAPI.Application.Dtos.Time;
using IlhadasLendasAPI.Domain.Entities;

namespace IlhadasLendasAPI.Application.Mappers
{
    public class TimeMappingProfile : Profile
    {
        public TimeMappingProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Time, ViewTimeDto>().ReverseMap();
            CreateMap<Time, PostTimeDto>().ReverseMap();
            CreateMap<Time, PutTimeDto>().ReverseMap();

            CreateMap<Jogador, ViewJogadorDto>().ReverseMap();
            CreateMap<Jogador, ReferenciaJogadorDto>().ReverseMap();
        }
    }
}