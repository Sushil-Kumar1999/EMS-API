using EMS.Core.Application.Exceptions;
using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Queries.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDto> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(query.UserId);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(ApplicationUser), query.UserId);
            }

            return new UserDto(user.Id, user.UserName, user.FirstName, user.LastName, user.Email, "");
        }
    }
}
