using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Weapons
{
    class ThrowingAxe : Ranged
    {
        public override int RangeIncrement => 10;

        public override int AmmoMax => 1;

        public override int Dice => 1;

        public override int Sides => 6;

        public override int Add => 0;

        public override int AttributeCorrection => -2;

        public override Piercing Piercing => Piercing.None;

        public override int Weight => 1;

        public override int Value => 50;

        public override string Description => "A single well balanced throwing axe";

        public override string Name => "Throwing axe";

        public override int Reload => 0;
    }
}
