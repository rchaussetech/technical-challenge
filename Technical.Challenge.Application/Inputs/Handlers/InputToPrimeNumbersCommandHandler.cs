using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Technical.Challenge.Application.Inputs.Commands;
using Technical.Challenge.Domain.Interfaces;
using Technical.Challenge.Domain.Models;

namespace Technical.Challenge.Application.Inputs.Handlers
{
    public class InputToPrimeNumbersCommandHandler : IRequestHandler<InputToPrimeNumbersCommand, InputDecomposed>
    {
        private readonly IPrimeNumberComputer _computer;

        public InputToPrimeNumbersCommandHandler(IPrimeNumberComputer computer)
        {
            _computer = computer;
        }

        public Task<InputDecomposed> Handle(InputToPrimeNumbersCommand request, CancellationToken cancellationToken)
        {
            return _computer.Process(request.Number);
        }
    }
}
