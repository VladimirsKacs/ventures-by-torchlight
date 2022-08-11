using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Melee:Weapon
    {
        new public void Eqiup(Adventurer adventurer)
        {
            base.Eqiup(adventurer);
            if (adventurer.Melee != null)
                adventurer.Melee.Unequip(adventurer);
            adventurer.Melee = this;
        }

        new public void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Melee = null;
        }
    }
}
