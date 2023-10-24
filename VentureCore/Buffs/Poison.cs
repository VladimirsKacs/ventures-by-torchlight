using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Buffs
{
    public class Poison:Buff
    {
        public override string Name => "poison";

        public override void Apply(Adventurer adventurer)
        {
            base.Apply(adventurer);
            adventurer.Dexterity -= 1;
            adventurer.Strength -= 1;
        }

        public override void Remove(Adventurer adventurer)
        {
            base.Remove(adventurer);
            adventurer.Dexterity += 1;
            adventurer.Strength += 1;
        }
    }
}
