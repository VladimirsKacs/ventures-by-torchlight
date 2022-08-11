using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Weapon:Item
    {
        public abstract int Dice { get;}
        public abstract int Sides { get;}
        public abstract int Add { get;}
        public abstract int AttributeCorrection { get;}
    }
}
