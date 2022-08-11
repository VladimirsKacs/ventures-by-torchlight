using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Ranged:Weapon
    {
        public int RangeIncrement { get; set; }
        public int Ammo { get; set; }
        public int AmmoMax { get; set; }

        new public void Eqiup(Adventurer adventurer)
        {
            base.Eqiup(adventurer);
            if (adventurer.Ranged != null)
                adventurer.Ranged.Unequip(adventurer);
            adventurer.Ranged = this;
        }

        new public void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Ranged = null;
        }
    }
}
