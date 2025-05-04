using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightNap.Core.Competitions.Dto.Response
{
    public class CompetitionDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
