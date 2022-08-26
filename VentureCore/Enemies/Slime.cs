using System;
using System.Collections.Generic;
using System.Text;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    class Slime:Enemy
    {
        public Slime()
        {
            Strength = 4;
            Agility = 5;
            MeleeDice = 0;
            MeleeAdd = 1;
            Xp = 75;
            Hp = HpMax = 3;
            LootTable = new Dictionary<int, Item>
            {
                {0, new GreenGoo() },
                {50, new Again() }
            };
        }
    }
}
