using LightNap.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightNap.Core.Competitions.Entities
{
    public class LeaderboardItem
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public ApplicationUser? User { get; set; } = null!;
        public int LeaderboardId { get; set; }
        public Leaderboard? Leaderboard { get; set; } = null!;
        public int Score { get; set; }
        public int Rank { get; set; }

    }
}
