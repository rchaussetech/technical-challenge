using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Technical.Challenge.Application.DTOs;
using Technical.Challenge.Application.Interfaces;

namespace Technical.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrimeNumberController : ControllerBase
    {
        private readonly IPrimeNumberService _service;

        public PrimeNumberController(IPrimeNumberService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(InputDecomposedDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Decompose([FromBody] InputDTO dto)
        {
            try
            {
                if (dto is null) dto = new();

                if (dto.IsValid(out string errorMessage))
                {
                    InputDecomposedDTO result = await _service.Decompose(dto);
                    return Ok(result);
                }

                return BadRequest(errorMessage);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}