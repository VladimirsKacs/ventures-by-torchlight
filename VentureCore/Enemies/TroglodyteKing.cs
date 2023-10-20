using System.Collections.Generic;
using VentureCore.VendorTrash;
using VentureCore.Weapons;

namespace VentureCore.Enemies
{
    public class TroglodyteKing:Enemy
    {
        public TroglodyteKing()
        {
            Strength = 12;
            Agility = 8;
            MeleeDice = 1;
            MeleeSides = 6;
            Armor = 2;
            MeleeName = "battle scepter";
            Xp = 1500;
            Hp = HpMax = 20;
            Name = "Troglodyte king";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new BattleScepter(),2 },
                {new GoldRing(),1 },
            });
        }
    }
}
