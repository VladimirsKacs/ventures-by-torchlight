using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Items
{
    public class MinorHealthPotion : Consumable
    {
        public override int Weight => 1;

        public override int ChargesMax => 1;

        public override string Name => "Minor health potion";

        public override string Description => "A weaker formulation of the health potion. Can heal 1d3+1 hp.";

        public override int Value => 75;

        public new void Use(Adventurer adventurer)
        {
            base.Use(adventurer);
            var random = new Random();
            var heal = random.Next(2, 5);
            if (adventurer.Hp + heal < adventurer.HpMax)
                adventurer.Hp += heal;
            else
                adventurer.Hp = adventurer.HpMax;
        }
    }
}
