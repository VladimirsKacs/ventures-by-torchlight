using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Buff
    {
        public virtual void Apply(Adventurer adventurer)
        {
            adventurer.Buffs.Add(this);
        }

        public virtual void Remove(Adventurer adventurer)
        {
            if (!adventurer.Buffs.Contains(this))
                throw new Exception("not affecting!");
            adventurer.Buffs.Remove(this);
        }
    }
}
