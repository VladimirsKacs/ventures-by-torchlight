namespace VentureCore.Weapons
{
    public class Fists : Melee
    {
        public override int Dice => 0;

        public override int Sides => 0;

        public override int Add => 1;

        public override int AttributeCorrection => -5;

        public override int Weight => 0;

        public override int Value => 0;

        public override string Description => "#ERROR#";

        public override string Name => "Fists";

        public override Piercing Piercing => Piercing.Double;
    }
}
