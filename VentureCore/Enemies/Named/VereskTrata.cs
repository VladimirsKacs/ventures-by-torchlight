using System.Collections.Generic;
using VentureCore.Items;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class VereskTrata : Enemy
    {
        public VereskTrata()
        {
            Armor = 2;
            Strength = 9;
            Dexterity = 7;
            Agility = 13;
            MeleeSides = 6;
            MeleeDice = 1;
            MeleeName = "short sword";
            RangedSides = 3;
            RangedDice = 1;
            RangedName = "short bow";
            Ammo = 10;
            RangeIncrement = 30;
            FiringRange = 59;
            Xp = 500;
            Hp = HpMax = 7;
            Name = "Pfc. Veresk Trata";
            LootTable = new LootTable(
            new Dictionary<Item, int>{
                {new Nothing(), 1 }
            });
        }
    }
}
