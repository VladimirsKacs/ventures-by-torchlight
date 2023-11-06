namespace VentureCore.VendorTrash
{
    public class Piston : Item
    {
        public override int Weight => 0;

        public override int Value => 80;

        public override string Description => "A mechanical piston still in good condition.";

        public override string Name => "Piston";
    }
}
