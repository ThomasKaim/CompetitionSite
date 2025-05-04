using LightNap.Core.Competitions.Dto.Response;
using LightNap.Core.Competitions.Extensions;
using LightNap.Core.Competitions.Interfaces;
using LightNap.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace LightNap.Core.Competitions.Services
{
    /// <summary>
    /// Service for logged-in business functionality.
    /// </summary>
    public class CompetitionService(ApplicationDbContext db) : ICompetitionService
    {
        public async Task<List<CompetitionDto>> GetCompetitionsAsync()
        {
            var competitions = await db.Competitions.ToListAsync();
            return competitions.ToDtoList();
        }
    }
}
