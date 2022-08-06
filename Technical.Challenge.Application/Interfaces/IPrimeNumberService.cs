using System.Threading.Tasks;
using Technical.Challenge.Application.DTOs;

namespace Technical.Challenge.Application.Interfaces
{
    public interface IPrimeNumberService
    {
        Task<InputDecomposedDTO> Decompose(InputDTO dto);
    }
}
