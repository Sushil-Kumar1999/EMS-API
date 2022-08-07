using System.ComponentModel;

namespace EMS.Core.Application.Domain.Enums
{
    public enum UserRoles : long
    {
        [Description("Admin")]
        Admin = 0,
        [Description("Organiser")]
        Organiser = 1,
        [Description("Volunteer")]
        Volunteer = 2
    }
}
