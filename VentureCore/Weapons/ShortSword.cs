using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Weapons
{
    class ShortSword : Melee
    {
        public override int Dice => 1;

        public override int Sides => 6;

        public override int Add => 0;

        public override int AttributeCorrection => 0;

        public override int Weight => 1;

        public override int Value => 100;

        public override string Description => "A short sword, commonly used by guards";

        public override string Name => "Short sword";

        public override Piercing Piercing => Piercing.None;
    }
}
