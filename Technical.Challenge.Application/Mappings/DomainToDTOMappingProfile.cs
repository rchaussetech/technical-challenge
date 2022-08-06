using AutoMapper;
using Technical.Challenge.Application.DTOs;
using Technical.Challenge.Domain.Models;

namespace Technical.Challenge.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<InputDecomposed, InputDecomposedDTO>().ReverseMap();
        }
    }
}
