using System;

namespace EMS.Core.DataTransfer.Events.DataContracts
{
    public class CreateEventRequestDataContract
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
