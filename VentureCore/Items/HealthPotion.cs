﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore.Items
{
    public class HealthPotion : Consumable
    {
        public override int Weight => 1;

        public override int ChargesMax => 1;

        public override string Name => "Health potion";

        public override string Description => "Your basic health potion. Can heal 1d6 hp.";

        public override int Value => 75;

        new public void Use(Adventurer adventurer)
        {
            base.Use(adventurer);
            var random = new Random();
            var heal = random.Next(1, 7);
            if (adventurer.Hp + heal < adventurer.HpMax)
                adventurer.Hp += heal;
            else
                adventurer.Hp = adventurer.HpMax;
        }
    }
}