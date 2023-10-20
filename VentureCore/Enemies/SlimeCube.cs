using System.Collections.Generic;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class SlimeCube:Enemy
    {
        public SlimeCube()
        {
            Strength = 7;
            Agility = 7;
            MeleeDice = 1;
            MeleeSides = 3;
            MeleeAdd = 1;
            MeleeName = "massive pseudopod";
            Xp = 350;
            Hp = HpMax = 30;
            Name = "Green Slime Cube";
            LootTable = new LootTable(new Dictionary<Item, int>
            {
                { new GreenGoo(), 1 },
                { new Again(), 3 }
            });
        }
    }
}
