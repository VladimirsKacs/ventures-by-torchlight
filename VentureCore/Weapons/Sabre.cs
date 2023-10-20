namespace VentureCore.Weapons
{
    public class Sabre : Melee
    {
        public override int Dice => 2;

        public override int Sides => 3;

        public override int Add => 0;

        public override int AttributeCorrection => 0;

        public override int Weight => 2;

        public override int Value => 150;

        public override string Description => "Somewhat enlarged version of the cavalry sabre";

        public override string Name => "Sabre";

        public override Piercing Piercing => Piercing.Double;
    }
}
