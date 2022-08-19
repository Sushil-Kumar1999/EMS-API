using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;

namespace EMS.Core.Application.Domain.Users.Queries
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public string UserId { get; set; }

        public GetUserQuery(string userId)
        {
            UserId = userId;
        }
    }
}
