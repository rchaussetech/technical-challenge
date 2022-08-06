using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using Technical.Challenge.Application.DTOs;
using Technical.Challenge.Application.Inputs.Commands;
using Technical.Challenge.Application.Interfaces;
using Technical.Challenge.Domain.Models;

namespace Technical.Challenge.Application.Services
{
    public class PrimeNumberService : IPrimeNumberService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PrimeNumberService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<InputDecomposedDTO> Decompose(InputDTO dto)
        {
            InputToPrimeNumbersCommand cmd = _mapper.Map<InputToPrimeNumbersCommand>(dto);

            InputDecomposed result = await _mediator.Send(cmd);

            return _mapper.Map<InputDecomposedDTO>(result);
        }
    }
}
