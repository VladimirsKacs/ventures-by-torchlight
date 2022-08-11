using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Weapons
{
    class Dagger : Melee
    {
        public override int Dice => 1;

        public override int Sides => 3;

        public override int Add => 0;

        public override int AttributeCorrection => 2;

        public override int Weight => 1;

        public override int Value => 50;

        public override string Description => "A dagger";

        public override string Name => "Dagger";

        public override Piercing Piercing => Piercing.None;
    }
}
