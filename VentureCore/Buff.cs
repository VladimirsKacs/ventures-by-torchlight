using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Buff
    {
        public abstract void Apply(Adventurer adventurer);
        public abstract void Remove(Adventurer adventurer);
    }
}
