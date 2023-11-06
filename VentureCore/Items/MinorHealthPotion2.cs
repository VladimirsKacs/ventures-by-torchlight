using System;

namespace VentureCore.Items
{
    public class MinorHealthPotion2 : Consumable
    {
        public override int Weight => 1;

        public override int ChargesMax => 1;

        public override string Name => "Ration C";

        public override string Description => "A ration which you can eat later to restore stamina";

        public override int Value => 75;

        public override void Use(Adventurer adventurer)
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
