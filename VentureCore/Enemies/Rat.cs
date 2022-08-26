using System;
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
            LootTable = new Dictionary<int, Item>
            {
                {0, null },
                {10, new SmallBone() },
                {30, new RatTeeh() },
                {50, new RatTail() },
                {70, new RatHide() },
                {80, new RatSkull() },
                {85, new SandPaper() },
                {87, new Pfennig() },
                {89, new Groshen() },
                {90, new Florin() },
                {91, new Again() }
            };
        }
    }
}
