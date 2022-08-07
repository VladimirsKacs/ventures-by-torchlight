using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public interface IItem
    {
        int Weight { get; set; }
        int Value { get; set; }
        void Eqiup(Adventurer adventurer);
        void Unequip(Adventurer adventurer);

    }
}
