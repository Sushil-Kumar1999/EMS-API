using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Queries.Handlers
{
    public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private UserManager<ApplicationUser> _userManager;

        public ListUsersQueryHandler(IUserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserDto>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<UserDto> userDtos = null;

            if (request.Role == null)
            {
                IEnumerable<ApplicationUser> users = await _userRepository.ListAsync();
                userDtos = users.Select(x => new UserDto(x.Id, x.UserName, x.FirstName, x.LastName, x.Email, GetRole(x)));
            }
            else
            {
                IEnumerable<ApplicationUser> users =  await _userManager.GetUsersInRoleAsync(request.Role);
                userDtos = users.Select(x => new UserDto(x.Id, x.UserName, x.FirstName, x.LastName, x.Email, request.Role));
            }

            return userDtos;
        }

        private string GetRole(ApplicationUser user)
        {
            IEnumerable<string> roles = _userManager.GetRolesAsync(user).Result;
            return roles.FirstOrDefault();
        }
    }
}
