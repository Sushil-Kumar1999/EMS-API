using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Infrastructure.Persistence;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Invitations.Commands.Handlers
{
    public class UpdateInvitationCommandHandler : IRequestHandler<UpdateInvitationCommand, long>
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IUnitOfWork _uow;

        public UpdateInvitationCommandHandler(IInvitationRepository invitationRepository, IUnitOfWork uow)
        {
            _invitationRepository = invitationRepository;
            _uow = uow;
        }

        public async Task<long> Handle(UpdateInvitationCommand command, CancellationToken cancellationToken)
        {
            Invitation invitation =  await _invitationRepository.GetByVolunteerIdAndEventIdAsync(command.VolunteerId, command.EventId);
            
            if (command.Response)
            {
                invitation.InvitationStatus = InvitationStatus.Accepted;
            }
            else
            {
                invitation.InvitationStatus = InvitationStatus.Declined;
            }
            
            await _uow.CommitAsync();

            return 0;
        }
    }
}
