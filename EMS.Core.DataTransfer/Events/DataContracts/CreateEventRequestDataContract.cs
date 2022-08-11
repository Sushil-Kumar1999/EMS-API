using System;

namespace EMS.Core.DataTransfer.Events.DataContracts
{
    public class CreateEventRequestDataContract
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
