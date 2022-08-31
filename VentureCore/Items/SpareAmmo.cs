namespace VentureCore.Items
{
    public class SpareAmmo : Consumable
    {
        public override int Weight => 1;

        public override int Value => 0;

        public override string Description => "Spare ammo for a ranged weapon";

        public override string Name => "Spare ammo";

        public override int ChargesMax => 1;
    }
}
