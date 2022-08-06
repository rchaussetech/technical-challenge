using System.Threading.Tasks;
using Technical.Challenge.Domain.Models;

namespace Technical.Challenge.Domain.Interfaces
{
    public interface IPrimeNumberComputer
    {
        Task<InputDecomposed> Process(int number);
    }
}
