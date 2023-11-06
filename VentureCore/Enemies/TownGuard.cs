using System.Collections.Generic;
using VentureCore.Items;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class TownGuard:Enemy
    {
        public TownGuard()
        {
            Armor = 2;
            Strength = 10;
            Dexterity = 10;
            Agility = 10;
            MeleeSides = 6;
            MeleeDice = 1;
            MeleeName = "short sword";
            RangedSides = 3;
            RangedDice = 1;
            RangedName = "short bow";
            Ammo = 3;
            RangeIncrement = 15;
            FiringRange = 30;
            Xp = 300;
            Hp = HpMax = 3;
            Name = "Town Guard";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new Nothing(), 1 }
            });
        }
    }
}
