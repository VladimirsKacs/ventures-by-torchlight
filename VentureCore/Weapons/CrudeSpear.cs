namespace VentureCore.Weapons
{
    public class CrudeSpear : Melee
    {
        public override int Dice => 1;

        public override int Sides => 4;

        public override int Add => 0;

        public override int AttributeCorrection => 0;

        public override int Weight => 1;

        public override int Value => 50;

        public override string Description => "A crude spear with a rock point";

        public override string Name => "Crude Spear";

        public override Piercing Piercing => Piercing.None;
    }
}
