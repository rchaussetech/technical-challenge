using System.Collections.Generic;
using System.Threading.Tasks;
using Technical.Challenge.Application.DTOs;

namespace Technical.Challenge.Application.Interfaces
{
    public interface IDecomposeNumberService
    {
        Task<InputDecomposedDTO> Decompose(InputDTO dto);
    }
}
