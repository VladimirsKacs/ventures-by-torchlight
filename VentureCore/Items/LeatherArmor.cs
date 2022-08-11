using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Items
{
    class LeatherArmor : Item
    {
        public override int Weight => 2;

        public override int Value => 50;

        public override string Description => "A sturdy amror made out of boiled leather. Adds +2 AC";

        public override string Name => "Leather armor";

        new public void Eqiup(Adventurer adventurer)
        {
            base.Eqiup(adventurer);
            adventurer.Armor += 2;
        }

        new public void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Armor -= 2;
        }
    }
}
