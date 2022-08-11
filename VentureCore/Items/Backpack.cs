using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Items
{
    class Backpack : Item
    {
        public override int Weight => -1;

        public override int Value => 50;

        public override string Description => "A sack that goes on your back and distrubutes the weight more evenly";

        public override string Name => "Backpack";
    }
}
