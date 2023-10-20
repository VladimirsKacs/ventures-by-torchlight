using System.Collections.Generic;
using VentureCore.Items;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class TroglodyteScout:Enemy
    {
        public TroglodyteScout()
        {
            Armor = 1;
            Strength = 6;
            Dexterity = 10;
            Agility = 10;
            MeleeSides = 3;
            MeleeDice = 1;
            MeleeName = "her last javelin";
            RangedSides = 3;
            RangedDice = 1;
            RangedName = "javelin";
            Ammo = 3;
            RangeIncrement = 15;
            FiringRange = 30;
            Xp = 300;
            Hp = HpMax = 3;
            Name = "Troglodyte Scout";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new CatHide(), 20 },
                {new RatHide(), 20 },
                {new HideArmor(), 20},
                {new Pfennig(),5 },
                {new Groshen(),2 },
                {new Florin(),1 },
                {new Again(), 65 }
            });
        }
    }
}
