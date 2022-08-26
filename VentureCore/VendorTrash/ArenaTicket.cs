namespace VentureCore.VendorTrash
{
    public class ArenaTicket : Item
    {
        public override int Weight => 0;

        public override int Value => 25;

        public override string Description => "A ticket to the weekly competition in the Arena";

        public override string Name => "Arena ticket";
    }
}
