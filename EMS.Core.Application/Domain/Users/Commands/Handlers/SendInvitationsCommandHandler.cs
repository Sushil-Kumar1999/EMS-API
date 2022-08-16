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

                await _mailService.SendEmailAsync(request.EmailAddresses, "Invitation to event", content);
            }

            return 1;
        }
    }
}
