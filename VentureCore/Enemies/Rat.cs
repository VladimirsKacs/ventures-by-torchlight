﻿using System;
using System.Collections.Generic;
using System.Text;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    class Rat:Enemy
    {
        public Rat()
        {
            Strength = 5;
            Agility = 10;
            MeleeDice = 1;
            MeleeSides = 3;
            Xp = 100;
            Hp = HpMax = 1;
            Name = "Rat";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {null, 10 },
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
            });
        }
    }
}
