namespace VentureCore.Items
{
    public class PlateArmor : Item
    {
        public override int Weight => 5;

        public override int Value => 500;

        public override string Description => "A full set of plate armor. Adds +10 AC, but reduces strength and dexterity by 2 and agility by 5.";

        public override string Name => "Plate armor";

        public override void Equip(Adventurer adventurer)
        {
            base.Equip(adventurer);
            adventurer.Armor += 10;
            adventurer.Agility -= 5;
            adventurer.Strength -= 2;
            adventurer.Dexterity -= 2;
        }

        public override void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Armor -= 10;
            adventurer.Agility += 5;
            adventurer.Strength += 2;
            adventurer.Dexterity += 2;
        }
    }
}
