using MediatR;
using Technical.Challenge.Domain.Models;

namespace Technical.Challenge.Application.Inputs.Commands
{
    public class InputToPrimeNumbersCommand : IRequest<InputDecomposed>
    {
        public int Number { get; set; }
    }
}
