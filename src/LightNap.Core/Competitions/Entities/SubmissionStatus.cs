using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightNap.Core.Competitions.Entities
{
    public enum SubmissionStatus
    {
        Queued,
        Running,
        Accepted,
        Incorrect,
        TimeLimitExceeded,
        Rejected,
        Error
    }
}
