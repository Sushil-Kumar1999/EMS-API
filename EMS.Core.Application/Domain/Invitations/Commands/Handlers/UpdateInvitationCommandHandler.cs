using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Infrastructure.Persistence;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Core.DataTransfer.Users.DataContracts;
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
            foreach (VolunteerDetailsDataContract volunteer in command.VolunteerDetails)
            {
                Invitation invitation =  await _invitationRepository.GetByVolunteerIdAndEventIdAsync(volunteer.VolunteerId, command.EventId);
                invitation.InvitationStatus = command.InvitationStatus;
            }
            
            await _uow.CommitAsync();

            // TODO: if invitation status is confirmed or rejected send emails to affected volunteers

            return 0;
        }
    }
}
