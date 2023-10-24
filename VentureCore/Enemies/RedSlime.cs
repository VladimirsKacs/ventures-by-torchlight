using System.Collections.Generic;
using VentureCore.Buffs;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class RedSlime:Enemy
    {
        public RedSlime()
        {
            Strength = 12;
            Agility = 8;
            MeleeDice = 1;
            MeleeSides = 6;
            MeleeAdd = 0;
            MeleeName = "pseudopod";
            Xp = 450;
            Hp = HpMax = 6;
            Name = "Red Slime";
            OffensiveBuff = new Poison();
            LootTable = new LootTable(new Dictionary<Item, int>
            {
                { new RedGoo(), 5 },
                { new Again(), 6 }
            });
        }
    }
}
