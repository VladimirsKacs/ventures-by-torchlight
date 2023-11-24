using System.Collections.Generic;
using VentureCore.Items;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    //DECEASED on Turn 37
    public class VereskTrata : Enemy
    {
        public VereskTrata()
        {
            Armor = 1;
            Strength = 9;
            Dexterity = 10;
            Agility = 13;
            MeleeSides = 4;
            MeleeDice = 1;
            MeleeName = "crude spear";
            RangedSides = 3;
            RangedDice = 1;
            RangedName = "javelin";
            Ammo = 3;
            RangeIncrement = 15;
            FiringRange = 29;
            Xp = 500;
            Hp = HpMax = 7;
            Name = "Pfc. Veresk Trata in troglodyte costume";
            LootTable = new LootTable(
            new Dictionary<Item, int>{
                {new Nothing(), 1 }
            });
        }
    }
}
