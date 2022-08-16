using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Domain.Users.Commands;
using EMS.Core.DataTransfer.Users.DataContracts;
using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Api.Controllers
{
    [Route("volunteers")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VolunteersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VolunteersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("find")]
        [Produces("application/json")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> FindVolunteersAsync([FromQuery] FindVolunteersRequestDataContract request)
        {
            var query = new FindVolunteersCommand(request.MinAge, request.MaxAge, request.MinHeight,
                                                request.MaxHeight, request.MinWeight, request.MaxWeight);
            IEnumerable<UserDto> volunteers = await _mediator.Send(query);

            return Ok(volunteers);
        }
    }
}
