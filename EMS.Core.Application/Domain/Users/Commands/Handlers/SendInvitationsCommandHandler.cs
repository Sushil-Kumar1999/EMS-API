using EMS.Core.Application.Domain.Events;
using EMS.Core.Application.Domain.Invitations;
using EMS.Core.Application.Domain.Users.Services;
using EMS.Core.Application.Infrastructure.Persistence;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Core.DataTransfer.Invitations.DataContracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Commands.Handlers
{
    public class SendInvitationsCommandHandler : IRequestHandler<SendInvitationsCommand, int>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        private readonly IInvitationRepository _invitationRepository;
        private readonly IUnitOfWork _uow;

        public SendInvitationsCommandHandler(IEventRepository eventRepository,
                                             IMailService mailService, IConfiguration configuration,
                                             IInvitationRepository invitationRepository, IUnitOfWork uow)
        {
            _eventRepository = eventRepository;
            _mailService = mailService;
            _configuration = configuration;
            _invitationRepository = invitationRepository;
            _uow = uow;
        }

        public async Task<int> Handle(SendInvitationsCommand command, CancellationToken cancellationToken)
        {
            Event @event = await _eventRepository.GetByIdAsync(command.EventId);
            var assembly = Assembly.GetEntryAssembly();
            var resourceStream = assembly.GetManifestResourceStream("EMS.Api.EmailTemplates.invitation-to-event.html");

            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                string emailTemplate = await reader.ReadToEndAsync();
                string baseUrl = $"{_configuration["LocalUrl"]}/invitations/respond";
                string content = emailTemplate
                    .Replace("{{Title}}", @event.Title)
                    .Replace("{{Location}}", @event.Location)
                    .Replace("{{Description}}", @event.Description)
                    .Replace("{{StartDate}}", @event.StartDate.ToString("dddd dd MMMM yyyy hh:mm tt"))
                    .Replace("{{EndDate}}", @event.EndDate.ToString("dddd dd MMMM yyyy hh:mm tt"))
                    .Replace("{{EventId}}", command.EventId.ToString())
                    .Replace("{{BaseUrl}}", baseUrl);

                foreach (VolunteerDetailsDataContract detail in command.VolunteerDetails)
                {
                    string htmlContent = content.Replace("{{VolunteerId}}", detail.VolunteerId)
                                                .Replace("{{VolunteerEmail}}", detail.VolunteerEmail);

                    await _mailService.SendEmailAsync(detail.VolunteerEmail, "Invitation to event", htmlContent);

                    await SaveInvitation(command.EventId, detail.VolunteerId);
                }
            }

            return 0;
        }

       private async Task SaveInvitation(long eventId, string volunteerId)
       {
            Invitation invitation = new Invitation
            {
                EventId = eventId,
                VolunteerId = volunteerId,
                InvitationStatus = Enums.InvitationStatus.Unresponded,
                Status = 1
            };

            await _invitationRepository.AddAsync(invitation);
            await _uow.CommitAsync();
       }
    }
}
