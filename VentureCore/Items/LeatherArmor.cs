namespace VentureCore.Items
{
    public class LeatherArmor : Item
    {
        public override int Weight => 2;

        public override int Value => 50;

        public override string Description => "A sturdy armor made out of boiled leather. Adds +2 AC";

        public override string Name => "Leather armor";

        public override void Equip(Adventurer adventurer)
        {
            base.Equip(adventurer);
            adventurer.Armor += 2;
        }

        public override void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Armor -= 2;
        }
    }
}
