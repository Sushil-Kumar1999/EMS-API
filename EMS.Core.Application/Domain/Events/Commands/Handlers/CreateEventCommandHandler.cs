using EMS.Core.Application.Infrastructure.Persistence;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Events.Commands.Handlers
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, long>
    {
        private readonly IUnitOfWork _uow;
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IUnitOfWork uow, IEventRepository eventRepository)
        {
            _uow = uow;
            _eventRepository = eventRepository;
        }

        public async Task<long> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {
            Event newEvent = new Event
            {
                Name = command.Name,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
            };

            await _eventRepository.AddAsync(newEvent);
            await _uow.CommitAsync();

            return newEvent.Id;
        }
    }
}
