using System.Linq;
using System.Threading.Tasks;
using Technical.Challenge.Domain.Interfaces;
using Technical.Challenge.Domain.Models;

namespace Technical.Challenge.Infra.Data.Computers
{
    public class PrimeNumberComputer : IPrimeNumberComputer
    {
        private readonly IDecomposeNumberComputer _computer;

        public PrimeNumberComputer(IDecomposeNumberComputer computer)
        {
            _computer = computer;
        }

        public async Task<InputDecomposed> Process(int number)
        {
            InputDecomposed result = await _computer.Process(number);

            result.Numbers = result.Numbers.Where(IsPrimeNumber);

            return result;
        }

        private static bool IsPrimeNumber(int number)
        {
            bool isPrimeNumber = true;
            int factor = number / 2;
            for (int i = 2; i <= factor; i++)
            {
                if ((number % i) == 0)
                {
                    isPrimeNumber = false;
                    break;
                }
            }
            return isPrimeNumber;
        }
    }
}