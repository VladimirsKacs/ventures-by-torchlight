using System;
using System.Collections.Generic;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class Slime:Enemy
    {
        public Slime()
        {
            Strength = 4;
            Agility = 5;
            MeleeDice = 0;
            MeleeAdd = 1;
            MeleeName = "pseudopod";
            Xp = 75;
            Hp = HpMax = 3;
            Name = "Green Slime";
            LootTable = new LootTable(new Dictionary<Item, int>
            {
                { new GreenGoo(), 9 },
                { new Again(), 11 }
            });
        }
    }
}
