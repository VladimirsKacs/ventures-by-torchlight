﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Enemy
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Agility { get; set; }
        public int Hp { get; set; }
        public int HpMax { get; set; }
        public int Count { get; set; }
        public int MeleeDice { get; set; }
        public int MeleeSides { get; set; }
        public int MeleeAdd { get; set; }
        public int RangedDice { get; set; }
        public int RangedSides { get; set; }
        public int RangedAdd { get; set; }
        public int RangeIncement { get; set; }
        public int Ammo { get; set; }
        public int AmmoMax { get; set; }
        public int Xp { get; set; }
        public Dictionary<int, Item> LootTable { get; set; }
    }
}
