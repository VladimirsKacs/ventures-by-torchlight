namespace VentureCore.Items
{
    public class HideArmor : Item
    {
        public override int Weight => 1;

        public override int Value => 25;

        public override string Description => "A crudely made, but effective, armor made of animal hides. Adds +1 AC";

        public override string Name => "Hide armor";

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
