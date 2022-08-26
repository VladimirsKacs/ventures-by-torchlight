namespace VentureCore.Items
{
    public class LockPick : Item
    {
        public override int Weight => 1;

        public override int Value => 50;

        public override string Description => "A set of tools designed to open locks";

        public override string Name => "Lockpicks";
    }
}
