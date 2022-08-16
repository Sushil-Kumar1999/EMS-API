using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.DataTransfer.Users.DataContracts
{
    public class FindVolunteersRequestDataContract
    {
        public double MinAge { get; set; }
        public double MaxAge { get; set; }

        public double MinHeight { get; set; }

        public double MaxHeight { get; set; }
        public double MinWeight { get; set; }

        public double MaxWeight{ get; set; }

    }
}
