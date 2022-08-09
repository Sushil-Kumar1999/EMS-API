using EMS.Core.Application.Infrastructure.Persistence;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Core.Application.Infrastructure.Security;
using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Commands.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserRegistrationResponseDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenManager _tokenManager;
        private readonly IUnitOfWork _uow;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager,
                                          ITokenManager tokenManager,
                                          IUnitOfWork uow)
        {
            _userManager = userManager;
            _tokenManager = tokenManager;
            _uow = uow;
        }

        public async Task<UserRegistrationResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null)
            {
                throw new Exception("Email already in use");
            }

            var newUser = new ApplicationUser
            {
                EmailConfirmed = true,
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, request.Password);

            if(!result.Succeeded)
            {
                throw new Exception("Creation of user failed");
            }

            await _userManager.AddToRoleAsync(newUser, request.Role);
            await _uow.CommitAsync();

            var token = await _tokenManager.GenerateTokenAsync(newUser);

            return new UserRegistrationResponseDto(token);
        }
    }
}
