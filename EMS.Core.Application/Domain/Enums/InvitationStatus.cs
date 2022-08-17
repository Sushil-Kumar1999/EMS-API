using System.ComponentModel;

namespace EMS.Core.Application.Domain.Enums
{
    public enum InvitationStatus : long
    {
        [Description("Invited")]
        Invited = 1,
        [Description("Accepted")]
        Accepted = 2,
        [Description("Declined")]
        Declined = 3,
        [Description("Confirmed")]
        Confirmed = 4,
        [Description("Rejected")]
        Rejected = 5
    }
}
