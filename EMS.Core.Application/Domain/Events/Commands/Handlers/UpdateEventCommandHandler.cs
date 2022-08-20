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
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, long>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _uow;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork uow)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task<long> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
        {
            Event @event = await _eventRepository.GetByIdAsync(command.EventId);
            @event.Title = command.Title;
            @event.Description = command.Description;
            @event.Location = command.Location;
            @event.StartDate = command.StartDate;
            @event.EndDate = command.EndDate;
            await _eventRepository.UpsertAsync(@event);
            await _uow.CommitAsync();

            return 0;
        }
    }
}
