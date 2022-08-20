using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Domain.Events.Commands;
using EMS.Core.Application.Domain.Events.Queries;
using EMS.Core.DataTransfer.Events.DataContracts;
using EMS.Core.DataTransfer.Events.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Api.Controllers
{
    [Route("events")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{eventId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> GetAsync([FromRoute] long eventId)
        {
            GetEventQuery query = new GetEventQuery(eventId);
            EventDto @event = await _mediator.Send(query);

            return Ok(@event);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> ListAsync()
        {
            ListEventsQuery query = new ListEventsQuery();
            IEnumerable<EventDto> events = await _mediator.Send(query);

            return Ok(events);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEventRequestDataContract request)
        {
            CreateEventCommand command = new CreateEventCommand(request.Title, request.Description, 
                                                                request.Location, request.StartDate,
                                                                request.EndDate);
            long eventId = await _mediator.Send(command);

            return Ok(eventId);
        }

        [HttpPatch("{eventId}")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> UpdateAsync([FromRoute] long eventId, UpdateEventRequestDataContract request)
        {
            UpdateEventCommand command = new UpdateEventCommand(eventId, request.Title, request.Description,
                request.Location, request.StartDate, request.EndDate);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("volunteer/{volunteerId}/invited")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> FindEventsInvitedToAsync([FromRoute] string volunteerId)
        {
            var query = new FindEventsInInvitationQuery(volunteerId, 0);
            IEnumerable<EventDto> events = await _mediator.Send(query);
            return Ok(events);
        }

        [HttpGet("volunteer/{volunteerId}/unresponded")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> FindEventsUnrespondedToAsync([FromRoute] string volunteerId)
        {
            var query = new FindEventsInInvitationQuery(volunteerId, InvitationStatus.Unresponded);
            IEnumerable<EventDto> events = await _mediator.Send(query);
            return Ok(events);
        }

        [HttpGet("volunteer/{volunteerId}/accepted")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> FindEventsAcceptedAsync([FromRoute] string volunteerId)
        {
            var query = new FindEventsInInvitationQuery(volunteerId, InvitationStatus.Accepted);
            IEnumerable<EventDto> events = await _mediator.Send(query);
            return Ok(events);
        }

        [HttpGet("volunteer/{volunteerId}/declined")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> FindEventsDeclinedAsync([FromRoute] string volunteerId)
        {
            var query = new FindEventsInInvitationQuery(volunteerId, InvitationStatus.Declined);
            IEnumerable<EventDto> events = await _mediator.Send(query);
            return Ok(events);
        }

        [HttpGet("volunteer/{volunteerId}/confirmed")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> FindEventsConfirmedForAsync([FromRoute] string volunteerId)
        {
            var query = new FindEventsInInvitationQuery(volunteerId, InvitationStatus.Confirmed);
            IEnumerable<EventDto> events = await _mediator.Send(query);
            return Ok(events);
        }

        [HttpGet("volunteer/{volunteerId}/rejected")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> FindEventsRejectedForAsync([FromRoute] string volunteerId)
        {
            var query = new FindEventsInInvitationQuery(volunteerId, InvitationStatus.Rejected);
            IEnumerable<EventDto> events = await _mediator.Send(query);
            return Ok(events);
        }
    }
}
