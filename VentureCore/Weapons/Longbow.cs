using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Weapons
{
    class Longbow : Ranged
    {
        public override int RangeIncrement => 50;

        public override int AmmoMax => 10;

        public override int Dice => 1;

        public override int Sides => 6;

        public override int Add => 1;

        public override int AttributeCorrection => -7;

        public override Piercing Piercing => Piercing.Half;

        public override int Weight => 2;

        public override int Value => 250;

        public override string Description => "A long bow, used in war. It takes a professional to use effectively";

        public override string Name => "Long bow";

        public override int Reload => 0;
    }
}
