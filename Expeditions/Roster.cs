using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentureCore;

namespace Expeditions
{
    internal class Roster
    {
        public List<Adventurer> Adventurers { get; set; }
        public Location Location { get; set; }
        public List<Item> Loot { get; set; }
    }
}
