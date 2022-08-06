using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Technical.Challenge.Application.Inputs.Commands;
using Technical.Challenge.Domain.Interfaces;
using Technical.Challenge.Domain.Models;

namespace Technical.Challenge.Application.Inputs.Handlers
{
    public class InputToDecomposeCommandHandler : IRequestHandler<InputToDecomposeCommand, InputDecomposed>
    {
        private readonly IDecomposeNumberComputer _computer;

        public InputToDecomposeCommandHandler(IDecomposeNumberComputer computer)
        {
            _computer = computer;
        }

        public Task<InputDecomposed> Handle(InputToDecomposeCommand request, CancellationToken cancellationToken)
        {
            return _computer.Process(request.Number);
        }
    }
}
