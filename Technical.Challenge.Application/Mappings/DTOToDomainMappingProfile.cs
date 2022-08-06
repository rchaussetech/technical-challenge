using AutoMapper;
using Technical.Challenge.Application.DTOs;
using Technical.Challenge.Application.Inputs.Commands;

namespace Technical.Challenge.Application.Mappings
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<InputDTO, InputToDecomposeCommand>();
            CreateMap<InputDTO, InputToPrimeNumbersCommand>();
        }
    }
}
