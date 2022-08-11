using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Events.Queries
{
    public class ListEventsQuery : IRequest<IEnumerable<EventDto>>
    {
    }
}
