using EMS.Core.Application.Exceptions;
using EMS.Core.Application.Infrastructure.Persistence;
using EMS.Core.Application.Infrastructure.Security;
using EMS.Core.Application.Utils;
using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Commands.Handlers
{
    public class CreateVolunteerCommandHandler : IRequestHandler<CreateVolunteerCommand, UserRegistrationResponseDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenManager _tokenManager;
        private readonly ISecurityManager _securityManager;
        private readonly IUnitOfWork _uow;
        private readonly string _tempPassword;

        public CreateVolunteerCommandHandler(UserManager<ApplicationUser> userManager,
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

        public async Task<UserRegistrationResponseDto> Handle(CreateVolunteerCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                throw new ValidationException(new[] { "This email address is already in use" });

            }

            var volunteer = new Volunteer
            {
                EmailConfirmed = true,
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Height = request.Height,
                Weight = request.Weight
            };

            IdentityResult result = await _userManager.CreateAsync(volunteer, _tempPassword);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.Select(e => e.Description).ToString());
            }

            await _userManager.AddToRoleAsync(volunteer, "Volunteer");
            await _securityManager.SendConfirmationEmailAsync(volunteer, _tempPassword);
            await _uow.CommitAsync();

            var token = await _tokenManager.GenerateTokenAsync(volunteer);

            return new UserRegistrationResponseDto(token);
        }
    }
}
