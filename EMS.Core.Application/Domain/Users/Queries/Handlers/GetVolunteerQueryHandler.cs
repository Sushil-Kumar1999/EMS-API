using EMS.Core.Application.Exceptions;
using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Queries.Handlers
{
    public class GetVolunteerQueryHandler : IRequestHandler<GetVolunteerQuery, VolunteerDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetVolunteerQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<VolunteerDto> Handle(GetVolunteerQuery query, CancellationToken cancellationToken)
        {
            ApplicationUser appUser = await _userManager.FindByIdAsync(query.VolunteerId);

            if (appUser == null)
            {
                throw new EntityNotFoundException(nameof(Volunteer), query.VolunteerId);
            }

            string appUserString = JsonConvert.SerializeObject(appUser);
            Volunteer v = JsonConvert.DeserializeObject<Volunteer>(appUserString);

            return new VolunteerDto(v.Id, v.UserName, v.FirstName, v.LastName, v.Email, "Volunteer", v.DateOfBirth, v.Height, v.Weight);
        }
    }
}
