using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Weapons
{
    class RustyDagger : Melee
    {
        public override int Dice => 1;

        public override int Sides => 3;

        public override int Add => -1;

        public override int AttributeCorrection => 1;

        public override int Weight => 1;

        public override int Value => 20;

        public override string Description => "An old dagger covered in rust";

        public override string Name => "Rusty dagger";

        public override Piercing Piercing => Piercing.None;
    }
}
