using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Domain.Users.Commands;
using EMS.Core.DataTransfer.Invitations.DataContracts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EMS.Api.Controllers
{
    [Route("invitations")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InvitationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvitationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("send")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> SendInvitationsAsync([FromBody] SendInvitationRequestDataContract request)
        {
            var command = new SendInvitationsCommand(request.EventId, request.VolunteerDetails);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("respond")]
        [AllowAnonymous]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> RespondToInvitationAsync([FromForm] RespondToInvitationDataContract dc)
        {
            Console.WriteLine($"EventID : {dc.EventId}\nVolunteerID: {dc.VolunteerId}\nVolunteerEmail: {dc.VolunteerEmail}\nResponse: {dc.Response}");
            await Task.CompletedTask;

            return NoContent() ;
        }
    }
}
