using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Exceptions;
using EMS.Core.Application.Infrastructure.Persistence;
using EMS.Core.Application.Infrastructure.Security;
using EMS.Core.Application.Utils;
using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Commands.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserRegistrationResponseDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenManager _tokenManager;
        private readonly ISecurityManager _securityManager;
        private readonly IUnitOfWork _uow;
        private readonly string _tempPassword;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager,
                                          ITokenManager tokenManager,
                                          ISecurityManager securityManager,
                                          IUnitOfWork uow)
        {
            _userManager = userManager;
            _tokenManager = tokenManager;
            _securityManager = securityManager;
            _uow = uow;
            _tempPassword = RandomValuesGenerator.RandomPassword();
        }

        public async Task<UserRegistrationResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null)
            {
                throw new ValidationException(new[] { "This email address is already in use" });
            }

            (IdentityResult result, ApplicationUser newUser) = request.Role == nameof(UserRoles.Volunteer)
                ? await RegisterNewVolunteer(request)
                : await RegisterNewNonVolunteer(request);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.Select(e => e.Description).ToString());
            }

            await _userManager.AddToRoleAsync(newUser, request.Role);
            await _securityManager.SendConfirmationEmailAsync(newUser, _tempPassword);
            await _uow.CommitAsync();

            var token = await _tokenManager.GenerateTokenAsync(newUser);

            return new UserRegistrationResponseDto(token);
        }

        private async Task<(IdentityResult, ApplicationUser)> RegisterNewVolunteer(RegisterUserCommand request)
        {
            var newUser = new Volunteer
            {
                EmailConfirmed = true,
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, _tempPassword);

            return (result, newUser);
        }

        private async Task<(IdentityResult, ApplicationUser)> RegisterNewNonVolunteer(RegisterUserCommand request)
        {
            var newUser = new ApplicationUser
            {
                EmailConfirmed = true,
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, _tempPassword);

            return (result, newUser);
        }
    }
}
