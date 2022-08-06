using FluentAssertions;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Technical.Challenge.Application.DTOs;
using Technical.Challenge.Tests.Abstracts;
using Xunit;

namespace Technical.Challenge.Tests.Controllers
{
    public class PrimeNumberControllerTest : XUnitBaseTest
    {
        public const string PRIME_NUMBER_URI = "/api/PrimeNumber";

        [Fact]
        public async Task DecomposeTest()
        {
            InputDTO dto = new()
            {
                Number = 50,
            };

            string requestJson = JsonConvert.SerializeObject(dto);
            string responseJson = await base.PostAsync(PRIME_NUMBER_URI, requestJson);

            InputDecomposedDTO inputDecomposed = JsonConvert.DeserializeObject<InputDecomposedDTO>(responseJson);

            inputDecomposed.Numbers.Count().Should().Be(3);
        }
    }
}