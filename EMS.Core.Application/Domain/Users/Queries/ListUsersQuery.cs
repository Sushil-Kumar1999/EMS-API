using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Users.Queries
{
    public class ListUsersQuery : IRequest<IEnumerable<UserDto>>
    {
        public string Role { get; }
        public ListUsersQuery(string role)
        {
            Role = role;
        }
    }
}
