using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Weapons
{
    class Stick : Melee
    {
        public override int Dice => 1;

        public override int Sides => 3;

        public override int Add => 0;

        public override int AttributeCorrection => -1;

        public override int Weight => 1;

        public override int Value => 10;

        public override string Description => "A random stick you could have picked up in the woods";

        public override string Name => "Stick";

        public override Piercing Piercing => Piercing.Double;
    }
}
