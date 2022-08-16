using EMS.Core.Application.Domain.Events;
using EMS.Core.Application.Domain.Users.Services;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using MediatR;
using System.IO;
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

        public SendInvitationsCommandHandler(IEventRepository eventRepository, IMailService mailService)
        {
            _eventRepository = eventRepository;
            _mailService = mailService;
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

                string baseUrl = $"https://localhost:5001/events/{request.EventId}/invitation";

                foreach (string recipientEmail in request.EmailAddresses)
                {
                    string yesURL = baseUrl + $"?volunteerEmail={recipientEmail}&response=true";
                    string noUrl = baseUrl + $"?volunteerEmail={recipientEmail}&response=false";

                    string htmlContent = content.Replace("{{YesURL}}", yesURL).Replace("{{NoURL}}", noUrl);

                    await _mailService.SendEmailAsync(recipientEmail, "Invitation to event", htmlContent);
                }
            }

            return 0;
        }
    }
}
