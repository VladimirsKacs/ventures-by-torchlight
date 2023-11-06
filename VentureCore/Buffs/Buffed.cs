using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Buffs
{
    public class Buffed:Buff
    {
        public override string Name => "buffed";

        public override void Apply(Adventurer adventurer)
        {
            base.Apply(adventurer);
            adventurer.Strength += 2;
            adventurer.Constitution -= 2;
        }

        public override void Remove(Adventurer adventurer)
        {
            base.Remove(adventurer);
            adventurer.Strength -= 2;
            adventurer.Constitution += 2;
        }
    }
}
