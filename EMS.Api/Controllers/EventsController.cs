using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Domain.Events.Commands;
using EMS.Core.Application.Domain.Events.Queries;
using EMS.Core.Application.Domain.Users.Commands;
using EMS.Core.DataTransfer.Events.DataContracts;
using EMS.Core.DataTransfer.Events.DTOs;
using EMS.Core.DataTransfer.Invitations.DataContracts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
        public async Task<IActionResult> GetAsync([FromRoute] long eventId)
        {
            GetEventQuery query = new GetEventQuery(eventId);
            EventDto @event = await _mediator.Send(query);

            return Ok(@event);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Organiser))]
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
    }
}
