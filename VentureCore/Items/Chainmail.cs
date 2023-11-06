namespace VentureCore.Items
{
    public class Chainmail : Item
    {
        public override int Weight => 3;

        public override int Value => 250;

        public override string Description => "An armor made of little interconnected rings. Adds +4 AC";

        public override string Name => "Chainmail armor";

        public override void Equip(Adventurer adventurer)
        {
            base.Equip(adventurer);
            adventurer.Armor += 4;
        }

        public override void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Armor -= 4;
        }
    }
}
