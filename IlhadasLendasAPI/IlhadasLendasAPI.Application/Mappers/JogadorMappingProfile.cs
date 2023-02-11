using AutoMapper;
using IlhadasLendasAPI.Application.Dtos.Jogador;
using IlhadasLendasAPI.Application.Dtos.Nacionalidade;
using IlhadasLendasAPI.Application.Dtos.Role;
using IlhadasLendasAPI.Domain.Entities;

namespace IlhadasLendasAPI.Application.Mappers
{
    public class JogadorMappingProfile : Profile
    {
        public JogadorMappingProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Jogador, ViewJogadorDto>().ReverseMap();
            CreateMap<Jogador, PutJogadorDto>().ReverseMap();
            CreateMap<Jogador, PostJogadorDto>().ReverseMap();
            CreateMap<Jogador, ReferenciaJogadorDto>().ReverseMap();

            CreateMap<Nacionalidade, ViewNacionalidadeDto>().ReverseMap();
            CreateMap<Role, ViewRoleDto>().ReverseMap();
        }
    }
}