using System;
using System.Collections.Generic;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class Rat:Enemy
    {
        public Rat(Random random)
        {
            Strength = 5;
            Agility = 10;
            MeleeDice = 1;
            MeleeSides = 3;
            MeleeName = "teeth";
            Xp = 100;
            Hp = HpMax = 1;
            Name = "Rat";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new SmallBone(),200 },
                {new RatTeeh(), 200 },
                {new RatTail(), 200 },
                {new RatHide(), 100 },
                {new RatSkull(), 50 },
                {new SandPaper(),20 },
                {new Pfennig(),20 },
                {new Groshen(),10 },
                {new Florin(),5 },
                {new Again(), 300 }
            }, random);
        }
    }
}
