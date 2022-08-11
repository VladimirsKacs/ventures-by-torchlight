using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Weapons
{
    class Crossbow : Ranged
    {
        public override int RangeIncrement => 20;

        public override int AmmoMax => 10;

        public override int Dice => 1;

        public override int Sides => 6;

        public override int Add => 0;

        public override int AttributeCorrection => 0;

        public override Piercing Piercing => Piercing.Half;

        public override int Weight => 2;

        public override int Value => 150;

        public override string Description => "An outdated crossbow";

        public override string Name => "Crossbow";

        public override int Reload => 1;
    }
}
