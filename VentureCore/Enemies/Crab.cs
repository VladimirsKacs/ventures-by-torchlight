using System.Collections.Generic;
using VentureCore.Items;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class Crab:Enemy
    {
        public Crab()
        {
            Armor = 5;
            Strength = 12;
            Agility = 10;
            MeleeDice = 1;
            MeleeSides = 6;
            MeleeName = "claws";
            Xp = 750;
            Hp = HpMax = 10;
            Name = "Kenyan Mangrove Crab";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new MinorHealthPotion2(), 1 }
            });
        }
    }
}
