using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Commands
{
    public class FindVolunteersCommand : IRequest<IEnumerable<UserDto>>
    {
        public double MinAge { get; set; }
        public double MaxAge { get; set; }

        public double MinHeight { get; set; }

        public double MaxHeight { get; set; }
        public double MinWeight { get; set; }

        public double MaxWeight { get; set; }

        public FindVolunteersCommand(double minAge, double maxAge, double minHeight,
                                       double maxHeight, double minWeight, double maxWeight)
        {
            MinAge = minAge;
            MaxAge = maxAge;
            MinHeight = minHeight;
            MaxHeight = maxHeight;
            MinWeight = minWeight;
            MaxWeight = maxWeight;
        }
    }
}
