using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Ranged:Weapon
    {
        public abstract int RangeIncrement { get;}
        public int Ammo { get; set; }
        public abstract int AmmoMax { get;}

        public abstract int Reload { get; }

        new public void Eqiup(Adventurer adventurer)
        {
            base.Eqiup(adventurer);
            if (adventurer.Ranged != null)
                adventurer.Ranged.Unequip(adventurer);
            adventurer.Ranged = this;
            Ammo = AmmoMax;
        }

        new public void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Ranged = null;
        }
    }
}
