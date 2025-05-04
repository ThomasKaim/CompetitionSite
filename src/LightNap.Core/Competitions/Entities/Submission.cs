using LightNap.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightNap.Core.Competitions.Entities
{
    internal class Submission
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public int ProblemId { get; set; }
        public Problem? Problem { get; set; } = null!;
        public int UserId { get; set; }
        public ApplicationUser? User { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsAccepted { get; set; } = false;
        public SubmissionStatus Status { get; set; } = SubmissionStatus.Queued;
        public string ErrorMessage { get; set; } = null!;
    }
}
