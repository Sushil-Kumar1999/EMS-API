using EMS.Core.Application.Domain.Users.Commands;
using EMS.Core.DataTransfer.Users.DTOs;
using EMS.Core.DataTransfer.Users.DataContracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using EMS.Core.Application.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace EMS.Api.Controllers.Users
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

        [HttpPost("register")]
        //[Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorsResponse))]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegistrationRequestDataContract request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid payload");
            }

            var command = new RegisterUserCommand(request.FirstName, request.LastName, request.Email, request.Role);
            UserRegistrationResponseDto response = await _mediator.Send(command);

            return Ok(response);
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
