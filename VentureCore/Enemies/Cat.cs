using System;
using System.Collections.Generic;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class Cat:Enemy
    {
        public Cat(Random random)
        {
            Strength = 6;
            Agility = 10;
            MeleeDice = 1;
            MeleeSides = 3;
            MeleeName = "claws";
            Xp = 150;
            Hp = HpMax = 4;
            Name = "Cat";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new SmallBone(),40 },
                {new CatHide(), 20 },
                {new CatPaw(), 20 },
                {new Nail(),5 },
                {new Pfennig(),5 },
                {new Groshen(),2 },
                {new Florin(),1 },
                {new Again(), 65 }
            }, random);
        }
    }
}
