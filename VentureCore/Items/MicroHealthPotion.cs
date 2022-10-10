namespace VentureCore.Items
{
    public class MicroHealthPotion : Consumable
    {
        public override int Weight => 1;

        public override int ChargesMax => 1;
        public override string Name => "One hit potion";
        public override string Description => "There's some health potion left at the bottom of this vial. It could heal 1 hitpoint.";

        public override int Value => 30;

        public override void Use(Adventurer adventurer)
        {
            base.Use(adventurer);
            if (adventurer.Hp < adventurer.HpMax)
                adventurer.Hp++;
        }
    }
}
