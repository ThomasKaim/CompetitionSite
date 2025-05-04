using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightNap.Core.Competitions.Entities
{
    internal class Problem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Content { get; set; }
        public int CompetitionId { get; set; }
        public Competition? Competition { get; set; } = null!;
    }
}
