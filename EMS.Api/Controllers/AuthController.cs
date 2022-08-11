using EMS.Core.Application.Domain.Users.Commands;
using EMS.Core.DataTransfer.Users.DTOs;
using EMS.Core.DataTransfer.Users.DataContracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EMS.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponseDto))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorsResponse))]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDataContract request)
        {
            if (ModelState.IsValid)
            {
                var command = new LoginCommand(request.Email, request.Password);
                LoginResponseDto loginResponse = await _mediator.Send(command);

                return Ok(loginResponse);
            }

            return BadRequest();
        }
    }
}
