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
                {new SmallBone(),20 },
                {new CatHide(), 10 },
                {new CatPaw(), 10 },
                {new Nail(),2 },
                {new Pfennig(),2 },
                {new Groshen(),1 },
                {new Florin(),1 },
                {new Again(), 25 }
            }, random);
        }
    }
}
