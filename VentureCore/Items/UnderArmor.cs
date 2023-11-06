namespace VentureCore.Items
{
    public class UnderArmor : Item
    {
        public override int Weight => 1;

        public override int Value => 50;

        public override string Description => "A padded shirt designed to make wearing armor more comfortable. May be used with other armor. Adds +1 AC";

        public override string Name => "Under armor";

        public override void Equip(Adventurer adventurer)
        {
            base.Equip(adventurer);
            adventurer.Armor += 1;
        }

        public override void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Armor -= 1;
        }
    }
}
