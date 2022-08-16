using MediatR;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Users.Commands
{
    public class SendInvitationsCommand : IRequest<int>
    {
        public long EventId { get; }
        public IEnumerable<string> EmailAddresses { get; }

        public SendInvitationsCommand(long eventId, IEnumerable<string> emailAddresses)
        {
            EventId = eventId;
            EmailAddresses = emailAddresses;
        }
    }
}
