using System.Collections.Generic;
using VentureCore.Items;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class FitzCerg : Enemy
    {
        public FitzCerg()
        {
            Armor = 1;
            Strength = 9;
            Dexterity = 4;
            Agility = 11;
            MeleeSides = 6;
            MeleeDice = 1;
            MeleeName = "short sword";
            RangedSides = 3;
            RangedDice = 1;
            RangedName = "short bow";
            Ammo = 10;
            RangeIncrement = 30;
            FiringRange = 29;
            Xp = 300;
            Hp = HpMax = 3;
            Name = "Pvt. Fitz Cerg";
            LootTable = new LootTable(
            new Dictionary<Item, int>{
                {new Nothing(), 1 }
            });
        }
    }
}
