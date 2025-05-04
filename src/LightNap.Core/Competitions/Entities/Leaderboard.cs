using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightNap.Core.Competitions.Entities
{
    public class Leaderboard
    {
        public int CompetitionId { get; set; }
        public Competition? Competition { get; set; } = null!;
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
