using MediatR;
using System;

namespace EMS.Core.Application.Domain.Events.Commands
{
    public class CreateEventCommand : IRequest<long>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CreateEventCommand(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
