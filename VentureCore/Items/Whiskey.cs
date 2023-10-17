using VentureCore.Buffs;

namespace VentureCore.Items
{
    public class Whiskey : Consumable
    {
        public override int Weight => 1;

        public override int ChargesMax => 1;
        public override string Name => "Whiskey";
        public override string Description => "Good old Aqua Vitae. Heals 1 HP and increases HPMax by 1 for the rest of the day, at the expense of a point each of Agility, Dexterity and Strength.";

        public override int Value => 20;

        public override void Use(Adventurer adventurer)
        {
            base.Use(adventurer);
            new Drunk().Apply(adventurer);
            adventurer.Hp++;
        }
    }
}
