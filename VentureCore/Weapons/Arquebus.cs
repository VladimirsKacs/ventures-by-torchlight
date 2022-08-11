using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Weapons
{
    class Arquebus : Ranged
    {
        public override int RangeIncrement => 15;

        public override int AmmoMax => 5;

        public override int Dice => 1;

        public override int Sides => 6;

        public override int Add => 1;

        public override int AttributeCorrection => 0;

        public override Piercing Piercing => Piercing.Full;

        public override int Weight => 3;

        public override int Value => 300;

        public override string Description => "A modern firearm";

        public override string Name => "Arquebus";

        public override int Reload => 2;
    }
}
