using System;
using System.Collections.Generic;
using VentureCore.VendorTrash;

namespace VentureCore.Enemies
{
    public class Dog:Enemy
    {
        public Dog()
        {
            Strength = 7;
            Agility = 12;
            MeleeDice = 1;
            MeleeSides = 3;
            MeleeName = "bite";
            Xp = 250;
            Hp = HpMax = 4;
            Name = "Dog";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new SmallBone(),40 },
                {new Bone(),40 },
                {new Again(), 65 }
            });
        }
    }
}
