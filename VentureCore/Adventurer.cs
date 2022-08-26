using System;
using System.Collections.Generic;

namespace VentureCore
{
    public class Adventurer
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Hp { get; set; }
        public int HpMax { get; set; }
        public int Agility { get; set; }
        public int CarryCapacity { get; set; }
        public int Servitude { get; set; }
        public int Armor { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public int Encumbrance { get; set; }

        public Melee Melee { get; set; }
        public Ranged Ranged { get; set; }

        public List<Item> Items { get; set; }

        public string Range { get; set; }

        public int IdealRange { get; set; }
    }
}
