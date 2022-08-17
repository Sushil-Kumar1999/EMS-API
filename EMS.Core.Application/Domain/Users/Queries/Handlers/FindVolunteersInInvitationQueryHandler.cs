using EMS.Core.Application.Domain.Invitations;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Queries.Handlers
{
    public class FindVolunteersInInvitationQueryHandler : IRequestHandler<FindVolunteersInInvitationQuery, IEnumerable<UserDto>>
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IVolunteerRepository _volunteerRepository;

        public FindVolunteersInInvitationQueryHandler(IInvitationRepository invitationRepository, IVolunteerRepository volunteerRepository)
        {
            _invitationRepository = invitationRepository;
            _volunteerRepository = volunteerRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(FindVolunteersInInvitationQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Invitation> invitations =  await _invitationRepository
                .FindByEventIdAsync(query.EventId, query.InvitationStatus);

            IEnumerable<string> volunteerIds = invitations.Select(x => x.VolunteerId);
            IEnumerable<Volunteer> volunteers = await _volunteerRepository.GetAllByIds(volunteerIds);

            return volunteers.Select(v => new UserDto(v.Id, v.UserName, v.FirstName, v.LastName, v.Email, "Volunteer"));
        }
    }
}
