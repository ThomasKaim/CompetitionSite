using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightNap.Core.Competitions.Entities
{
    public class Competition
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
