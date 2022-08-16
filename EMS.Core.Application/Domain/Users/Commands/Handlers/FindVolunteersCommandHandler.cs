using EMS.Core.Application.Domain.Users.QueryObjects;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Commands.Handlers
{
    public class FindVolunteersCommandHandler : IRequestHandler<FindVolunteersCommand, IEnumerable<UserDto>>
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public FindVolunteersCommandHandler(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(FindVolunteersCommand request, CancellationToken cancellationToken)
        {
            var query = new FilterVolunteersQueryObject(request.MinAge, request.MaxAge, request.MinHeight,
                                                        request.MaxHeight, request.MinWeight, request.MaxHeight);
            IEnumerable<Volunteer> volunteers = await _volunteerRepository.FindAsync(query);

            return volunteers.Select(v => new UserDto(v.Id, v.UserName, v.FirstName, v.LastName, v.Email, "Volunteer"));
        }
    }
}
