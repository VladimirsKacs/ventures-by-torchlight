﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Weapons
{
    class Blunderbus : Ranged
    {
        public override int RangeIncrement => 10;

        public override int AmmoMax => 5;

        public override int Dice => 2;

        public override int Sides => 6;

        public override int Add => 1;

        public override int AttributeCorrection => 0;

        public override Piercing Piercing => Piercing.Double;

        public override int Weight => 3;

        public override int Value => 300;

        public override string Description => "A shot gun";

        public override string Name => "Blunderbuss";

        public override int Reload => 2;
    }
}