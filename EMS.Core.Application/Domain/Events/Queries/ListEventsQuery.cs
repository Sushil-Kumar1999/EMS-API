using EMS.Core.DataTransfer.Events.DTOs;
using MediatR;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Events.Queries
{
    public class ListEventsQuery : IRequest<IEnumerable<EventDto>>
    {
    }
}
