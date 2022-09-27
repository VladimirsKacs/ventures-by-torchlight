namespace VentureCore.Items
{
    public class Backpack : Item
    {
        public override int Weight => -1;

        public override int Value => 50;

        public override string Description => "A sack that goes on your back and distributes the weight more evenly";

        public override string Name => "Backpack";
    }
}
