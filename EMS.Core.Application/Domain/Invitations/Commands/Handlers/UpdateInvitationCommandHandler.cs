using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Domain.Events;
using EMS.Core.Application.Domain.Users.Services;
using EMS.Core.Application.Infrastructure.Persistence;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Core.DataTransfer.Users.DataContracts;
using MediatR;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Invitations.Commands.Handlers
{
    public class UpdateInvitationCommandHandler : IRequestHandler<UpdateInvitationCommand, long>
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMailService _mailService;

        public UpdateInvitationCommandHandler(IInvitationRepository invitationRepository, IEventRepository eventRepository,
                                              IUnitOfWork uow, IMailService mailService)
        {
            _invitationRepository = invitationRepository;
            _eventRepository = eventRepository;
            _uow = uow;
            _mailService = mailService;
        }

        public async Task<long> Handle(UpdateInvitationCommand command, CancellationToken cancellationToken)
        {
            foreach (VolunteerDetailsDataContract volunteer in command.VolunteerDetails)
            {
                Invitation invitation = await _invitationRepository.GetByVolunteerIdAndEventIdAsync(volunteer.VolunteerId, command.EventId);
                invitation.InvitationStatus = command.InvitationStatus;
            }

            await _uow.CommitAsync();

            if (command.InvitationStatus == InvitationStatus.Confirmed || command.InvitationStatus == InvitationStatus.Rejected)
            {
                string emailTemplate = await GetEmailTemplate(command.InvitationStatus == InvitationStatus.Confirmed);
                string content = await GetEmailContent(emailTemplate, command.EventId);

                string subject = command.InvitationStatus == InvitationStatus.Confirmed ? "Confirmation for event" : "Thank you for your interest";
                foreach (VolunteerDetailsDataContract volunteer in command.VolunteerDetails)
                {
                    string htmlContent = content.Replace("{{RecipientEmail}}", volunteer.VolunteerEmail);
                    await _mailService.SendEmailAsync(volunteer.VolunteerEmail, subject, htmlContent);
                }
            }

            return 0;
        }

        private async Task<string> GetEmailTemplate(bool isStatusConfirmed)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            Stream resourceStream;
            if (isStatusConfirmed)
            {
                resourceStream = assembly.GetManifestResourceStream("EMS.Api.EmailTemplates.confirmation-email-template.html");
            } 
            else
            {
                resourceStream = assembly.GetManifestResourceStream("EMS.Api.EmailTemplates.rejection-email-template.html");
            }

            string emailTemplate = string.Empty;
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                emailTemplate = await reader.ReadToEndAsync();
            }

            return emailTemplate;
        }

        private async Task<string> GetEmailContent(string emailTemplate, long eventId)
        {
            Event @event = await _eventRepository.GetByIdAsync(eventId);
            string content = emailTemplate
                      .Replace("{{EventTitle}}", @event.Title)
                      .Replace("{{EventLocation}}", @event.Location)
                      .Replace("{{EventDescription}}", @event.Description)
                      .Replace("{{EventStartDate}}", @event.StartDate.ToString("dddd dd MMMM yyyy hh:mm tt"))
                      .Replace("{{EventEndDate}}", @event.EndDate.ToString("dddd dd MMMM yyyy hh:mm tt"));

            return content;
        }
    }
}
