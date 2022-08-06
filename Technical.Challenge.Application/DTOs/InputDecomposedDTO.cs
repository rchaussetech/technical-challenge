using System.Collections.Generic;

namespace Technical.Challenge.Application.DTOs
{
    public class InputDecomposedDTO
    {
        public int Input { get; set; }
        public IEnumerable<int> Numbers { get; set; }
    }
}
