using AutoMapper;
using IlhadasLendasAPI.Application.Dtos.Role;
using IlhadasLendasAPI.Domain.Entities;

namespace IlhadasLendasAPI.Application.Mappers
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Role, ViewRoleDto>().ReverseMap();
            CreateMap<Role, PutRoleDto>().ReverseMap();
            CreateMap<Role, PostRoleDto>().ReverseMap();
        }
    }
}