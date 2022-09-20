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
                {new SmallBone(),20 },
                {new RatTeeh(), 20 },
                {new RatTail(), 20 },
                {new RatHide(), 10 },
                {new RatSkull(), 5 },
                {new SandPaper(),2 },
                {new Pfennig(),2 },
                {new Groshen(),1 },
                {new Florin(),1 },
                {new Again(), 10 }
            }, random);
        }
    }
}
