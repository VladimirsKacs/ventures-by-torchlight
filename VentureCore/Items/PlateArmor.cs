using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Items
{
    class PlateArmor : Item
    {
        public override int Weight => 5;

        public override int Value => 500;

        public override string Description => "A full set of plate armor. Adds +10 AC, but reduces stength and dexterity by 2 and aglity by 5.";

        public override string Name => "Plate armor";

        new public void Eqiup(Adventurer adventurer)
        {
            base.Eqiup(adventurer);
            adventurer.Armor += 10;
            adventurer.Agility -= 5;
            adventurer.Strength -= 2;
            adventurer.Dexterity -= 2;
        }

        new public void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Armor -= 10;
            adventurer.Agility += 5;
            adventurer.Strength += 2;
            adventurer.Dexterity += 2;
        }
    }
}
