using System.Collections.Generic;
using VentureCore.Items;
using VentureCore.VendorTrash;
using VentureCore.Weapons;

namespace VentureCore.Enemies
{
    public class MechReaper:Enemy
    {
        public MechReaper()
        {
            Armor = 2;
            Strength = 15;
            Agility = 15;
            MeleeDice = 1;
            MeleeSides = 4;
            MeleeName = "scithe";
            Xp = 700;
            Hp = HpMax = 12;
            Name = "Mechanical Reaper";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new Cog(),8 },
                {new Spring(), 4 },
                {new MetalPlate(), 4 },
                {new BrokenSpreader(),1 },
                {new Again(), 13 }
            });
        }
    }
}
