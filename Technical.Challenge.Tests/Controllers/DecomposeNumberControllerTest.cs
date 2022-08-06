using FluentAssertions;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Technical.Challenge.Application.DTOs;
using Technical.Challenge.Tests.Abstracts;
using Xunit;

namespace Technical.Challenge.Tests.Controllers
{
    public class DecomposeNumberControllerTest : XUnitBaseTest
    {
        public const string DECOMPOSE_NUMBER_URI = "/api/DecomposeNumber";

        [Fact]
        public async Task DecomposeTest()
        {
            InputDTO dto = new()
            {
                Number = 50,
            };

            string requestJson = JsonConvert.SerializeObject(dto);
            string responseJson = await base.PostAsync(DECOMPOSE_NUMBER_URI, requestJson);

            InputDecomposedDTO inputDecomposed = JsonConvert.DeserializeObject<InputDecomposedDTO>(responseJson);

            inputDecomposed.Numbers.Count().Should().Be(6);
        }
    }
}