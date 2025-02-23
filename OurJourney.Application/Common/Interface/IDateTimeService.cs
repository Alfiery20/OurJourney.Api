using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurJourney.Application.Common.Interface
{
    public interface IDateTimeService
    {
        DateTime Now { get; }
        DateTime NowUtc { get; }
    }
}
