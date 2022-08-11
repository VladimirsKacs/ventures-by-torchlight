using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Weapons
{
    class LongSword : Melee
    {
        public override int Dice => 1;

        public override int Sides => 6;

        public override int Add => 1;

        public override int AttributeCorrection => -1;

        public override int Weight => 2;

        public override int Value => 150;

        public override string Description => "A, heavier, longer sword";

        public override string Name => "Long sword";

        public override Piercing Piercing => Piercing.None;
    }
}
