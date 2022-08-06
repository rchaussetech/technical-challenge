using System.Collections.Generic;
using System.Threading.Tasks;
using Technical.Challenge.Domain.Interfaces;
using Technical.Challenge.Domain.Models;

namespace Technical.Challenge.Infra.Data.Computers
{
    public class DecomposeNumberComputer : IDecomposeNumberComputer
    {
        public Task<InputDecomposed> Process(int number)
        {
            List<int> numbers = new();
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                    numbers.Add(i);
            }

            InputDecomposed inputDecomposed = new()
            {
                Input = number,
                Numbers = numbers,
            };

            return Task.FromResult(inputDecomposed);
        }
    }
}