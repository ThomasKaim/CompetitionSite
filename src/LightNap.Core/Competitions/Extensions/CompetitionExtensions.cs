using LightNap.Core.Competitions.Dto.Response;
using LightNap.Core.Competitions.Entities;
using LightNap.Core.Data.Entities;
using LightNap.Core.Profile.Dto.Response;

namespace LightNap.Core.Competitions.Extensions
{
   
    public static class CompetitionExtensions
    {
        
        public static CompetitionDto ToDto(this Competition competition)
        {
            return new CompetitionDto()
            {
                Id = competition.Id,
                Name = competition.Name,
            };
        }

        public static List<CompetitionDto> ToDtoList(this IEnumerable<Competition> competitions)
        {
            return competitions.Select(token => token.ToDto()).ToList();
        }
    }
}