using EMS.Core.Application.Domain.Users.Commands;
using EMS.Core.Application.Domain.Users.Queries;
using EMS.Core.DataTransfer.Users.DataContracts;
using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Api.Controllers.Users
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        // [Authorize(Roles = nameof(UserRoles.SuperAdmin) + "," + nameof(UserRoles.SalesAdmin) + "," + nameof(UserRoles.Management))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorsResponse))]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegistrationRequestDataContract request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid payload");
            }

            var command = new RegisterUserCommand(request.FirstName, request.LastName, request.Email, request.Password);
            UserRegistrationResponseDto response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> ListAsync([FromQuery] string role)
        {
            var query = new ListUsersQuery(role);
            var users = await _mediator.Send(query);

            return Ok(users);
        }
    }
}
