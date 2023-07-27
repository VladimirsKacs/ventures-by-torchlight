using System;
using System.Collections.Generic;
using VentureCore.Items;
using VentureCore.VendorTrash;
using VentureCore.Weapons;

namespace VentureCore.Enemies
{
    public class Troglodyte:Enemy
    {
        public Troglodyte(Random random)
        {
            Armor = 1;
            Strength = 7;
            Agility = 10;
            MeleeDice = 1;
            MeleeSides = 4;
            MeleeName = "spear";
            Xp = 200;
            Hp = HpMax = 4;
            Name = "Troglodyte Warrior";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new CrudeSpear(),40 },
                {new CatHide(), 20 },
                {new RatHide(), 20 },
                {new HideArmor(), 10},
                {new Pfennig(),5 },
                {new Groshen(),2 },
                {new Florin(),1 },
                {new Again(), 65 }
            }, random);
        }
    }
}
