using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Queries
{
    public class ListEventsQuery : IRequest<IEnumerable<EventDto>>
    {
    }
}
