using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Domain.Invitations.Commands;
using EMS.Core.Application.Domain.Users.Commands;
using EMS.Core.DataTransfer.Invitations.DataContracts;
using EMS.Core.DataTransfer.Users.DataContracts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var invitationStatus = dc.Response ? InvitationStatus.Accepted : InvitationStatus.Declined;
            var volunteersDetails = new VolunteerDetailsDataContract
            {
                VolunteerId = dc.VolunteerId,
                VolunteerEmail = dc.VolunteerEmail
            };

            var command = new UpdateInvitationCommand(dc.EventId, new[] { volunteersDetails }, invitationStatus);
            await _mediator.Send(command);

            return NoContent() ;
        }

        [HttpPost("confirm")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> ConfirmInvitationAsync([FromBody] UpdateInvitationsDataContract dc)
        {
            var command = new UpdateInvitationCommand(dc.EventId,dc.VolunteerDetails, InvitationStatus.Confirmed);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("reject")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> RejectInvitationAsync([FromBody] UpdateInvitationsDataContract dc)
        {
            var command = new UpdateInvitationCommand(dc.EventId, dc.VolunteerDetails, InvitationStatus.Rejected);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
