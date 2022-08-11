using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Consumable:Item
    {
        public int Charges { get; set; }
        public abstract int ChargesMax { get;}

        public void Use(Adventurer adventurer)
        {
            Charges--;
            if (Charges == 0)
                Unequip(adventurer);
        }

        new public void Eqiup(Adventurer adventurer)
        {
            base.Eqiup(adventurer);
            Charges = ChargesMax;
        }
    }
}
