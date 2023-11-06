namespace VentureCore.VendorTrash
{
    public class Tome : Item
    {
        public override int Weight => 0;

        public override int Value => 500;

        public override string Description => "A large illuminated book with pictures.";

        public override string Name => "Ancient tome";
    }
}
