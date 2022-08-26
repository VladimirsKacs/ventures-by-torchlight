using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Item
    {
        public abstract int Weight { get;}
        public abstract int Value { get;}

        public abstract string Description { get; }

        public abstract string Name { get; }
        public void Eqiup(Adventurer adventurer)
        {
            if (adventurer.Encumbrance + Weight > adventurer.CarryCapacity)
                throw new Exception("too heavy");
            adventurer.Items.Add(this);
            adventurer.Encumbrance += Weight;
        }
        public void Unequip(Adventurer adventurer)
        {
            if (!adventurer.Items.Contains(this))
                throw new Exception("not equipped");
            adventurer.Items.Remove(this);
            adventurer.Encumbrance -= Weight;
        }

        new public string ToString()
        {
            return Name;
        }

    }
}
