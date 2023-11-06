namespace VentureCore.VendorTrash
{
    public class Booklet : Item
    {
        public override int Weight => 0;

        public override int Value => 300;

        public override string Description => "A small illuminated book with pictures. It's bound to fetch a good price.";

        public override string Name => "Booklet";
    }
}
