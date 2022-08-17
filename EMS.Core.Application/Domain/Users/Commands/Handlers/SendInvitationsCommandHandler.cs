using EMS.Core.Application.Domain.Events;
using EMS.Core.Application.Domain.Users.Services;
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
        private IEventRepository _eventRepository;
        private IMailService _mailService;
        private IConfiguration _configuration;

        public SendInvitationsCommandHandler(IEventRepository eventRepository, IMailService mailService,
                                             IConfiguration configuration)
        {
            _eventRepository = eventRepository;
            _mailService = mailService;
            _configuration = configuration;
        }

        public async Task<int> Handle(SendInvitationsCommand request, CancellationToken cancellationToken)
        {
            Event @event = await _eventRepository.GetByIdAsync(request.EventId);

            var assembly = Assembly.GetEntryAssembly();
            var resourceStream = assembly.GetManifestResourceStream("EMS.Api.EmailTemplates.invitation-to-event.html");

            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                string emailTemplate = await reader.ReadToEndAsync();
                string content = emailTemplate
                    .Replace("{{Title}}", @event.Title)
                    .Replace("{{Location}}", @event.Location)
                    .Replace("{{Description}}", @event.Description)
                    .Replace("{{StartDate}}", @event.StartDate.ToString("dddd dd MMMM yyyy hh:mm tt"))
                    .Replace("{{EndDate}}", @event.EndDate.ToString("dddd dd MMMM yyyy hh:mm tt"));

                
                string baseUrl = $"{_configuration["LocalUrl"]}/invitations/respond?eventId={request.EventId}";

                foreach (VolunteerDetailsDataContract detail in request.VolunteerDetails)
                {
                    string yesURL = baseUrl + $"&volunteerId={detail.VolunteerId}&volunteerEmail={detail.VolunteerEmail}&response=true";
                    string noUrl = baseUrl + $"&volunteerId={detail.VolunteerId}&volunteerEmail={detail.VolunteerEmail}&response=false";

                    string htmlContent = content.Replace("{{YesURL}}", yesURL).Replace("{{NoURL}}", noUrl);

                    await _mailService.SendEmailAsync(detail.VolunteerEmail, "Invitation to event", htmlContent);
                }
            }

            return 0;
        }
    }
}
