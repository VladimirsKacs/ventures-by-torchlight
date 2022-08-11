using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Weapon:Item
    {
        public int Dice { get; set; }
        public int Sides { get; set; }
        public int Add { get; set; }
        public int AttributeCorrection { get; set; }
    }
}
