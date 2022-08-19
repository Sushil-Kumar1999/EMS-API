using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Domain.Users.Queries;
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

        [HttpGet("{volunteerId}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync([FromRoute] string volunteerId)
        {
            GetVolunteerQuery query = new GetVolunteerQuery(volunteerId);
            VolunteerDto user = await _mediator.Send(query);

            return Ok(user);
        }

        [HttpGet("find")]
        [Produces("application/json")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> FindVolunteersAsync([FromQuery] FindVolunteersRequestDataContract request)
        {
            var query = new FindVolunteersQuery(request.MinAge, request.MaxAge, request.MinHeight,
                                                request.MaxHeight, request.MinWeight, request.MaxWeight);
            IEnumerable<UserDto> volunteers = await _mediator.Send(query);

            return Ok(volunteers);
        }

        [HttpGet("event/{eventId}/invited")]
        public async Task<IActionResult> FindInvitedVolunteersAsync([FromRoute] long eventId)
        {
            var query = new FindVolunteersInInvitationQuery(eventId, 0);
            IEnumerable<UserDto> volunteers = await _mediator.Send(query);

            return Ok(volunteers);
        }

        [HttpGet("event/{eventId}/unresponded")]
        public async Task<IActionResult> FindUnrespondedVolunteersAsync([FromRoute] long eventId)
        {
            var query = new FindVolunteersInInvitationQuery(eventId, InvitationStatus.Unresponded) ;
            IEnumerable<UserDto> volunteers = await _mediator.Send(query);

            return Ok(volunteers);
        }

        [HttpGet("event/{eventId}/accepted")]
        public async Task<IActionResult> FindAcceptedVolunteersAsync([FromRoute] long eventId)
        {
            var query = new FindVolunteersInInvitationQuery(eventId, InvitationStatus.Accepted);
            IEnumerable<UserDto> volunteers = await _mediator.Send(query);

            return Ok(volunteers);
        }

        [HttpGet("event/{eventId}/declined")]
        public async Task<IActionResult> FindDeclinedVolunteersAsync([FromRoute] long eventId)
        {
            var query = new FindVolunteersInInvitationQuery(eventId, InvitationStatus.Declined);
            IEnumerable<UserDto> volunteers = await _mediator.Send(query);

            return Ok(volunteers);
        }

        [HttpGet("event/{eventId}/confirmed")]
        public async Task<IActionResult> FindConfirmedVolunteersAsync([FromRoute] long eventId)
        {
            var query = new FindVolunteersInInvitationQuery(eventId, InvitationStatus.Confirmed);
            IEnumerable<UserDto> volunteers = await _mediator.Send(query);

            return Ok(volunteers);
        }

        [HttpGet("event/{eventId}/rejected")]
        public async Task<IActionResult> FindRejectedVolunteersAsync([FromRoute] long eventId)
        {
            var query = new FindVolunteersInInvitationQuery(eventId, InvitationStatus.Rejected);
            IEnumerable<UserDto> volunteers = await _mediator.Send(query);

            return Ok(volunteers);
        }
    }
}
