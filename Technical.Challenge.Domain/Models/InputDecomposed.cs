using System.Collections.Generic;

namespace Technical.Challenge.Domain.Models
{
    public class InputDecomposed
    {
        public int Input { get; set; }
        public IEnumerable<int> Numbers { get; set; }
    }
}
