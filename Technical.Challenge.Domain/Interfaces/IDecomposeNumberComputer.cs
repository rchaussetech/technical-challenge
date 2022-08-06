using System.Threading.Tasks;
using Technical.Challenge.Domain.Models;

namespace Technical.Challenge.Domain.Interfaces
{
    public interface IDecomposeNumberComputer
    {
        Task<InputDecomposed> Process(int number);
    }
}
