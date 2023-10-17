using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Buffs
{
    public class Drunk:Buff
    {
        public override void Apply(Adventurer adventurer)
        {
            base.Apply(adventurer);
            adventurer.HpMax += 1;
            adventurer.Agility -= 1;
            adventurer.Dexterity -= 1;
            adventurer.Strength -= 1;
        }

        public override void Remove(Adventurer adventurer)
        {
            base.Remove(adventurer);
            adventurer.HpMax -= 1;
            if (adventurer.Hp > adventurer.HpMax)
                adventurer.Hp = adventurer.HpMax;
            adventurer.Agility += 1;
            adventurer.Dexterity += 1;
            adventurer.Strength += 1;
        }
    }
}
