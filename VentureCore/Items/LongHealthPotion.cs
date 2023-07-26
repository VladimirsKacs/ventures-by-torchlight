namespace VentureCore.Items
{
    public class LongHealthPotion : Consumable
    {
        public override int Weight => 1;

        public override int ChargesMax => 3;
        public override string Name => "Long health potion";
        public override string Description => "This potion comes with a measuring cup, so you always know how much to drink. It heals 1 hitpoint per use.";

        public override int Value => 100;

        public override void Use(Adventurer adventurer)
        {
            base.Use(adventurer);
            if (adventurer.Hp < adventurer.HpMax)
                adventurer.Hp++;
        }
    }
}
