using System;
using System.Collections.Generic;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class Wolf:Enemy
    {
        public Wolf(Random random)
        {
            Strength = 10;
            Agility = 15;
            MeleeDice = 1;
            MeleeSides = 6;
            Armor = 1;
            MeleeName = "jaws";
            Xp = 750;
            Hp = HpMax = 6;
            Name = "Wolf";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new WolfPelt(),1 },
            }, random);
        }
    }
}
