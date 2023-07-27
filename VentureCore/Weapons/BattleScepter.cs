namespace VentureCore.Weapons
{
    public class BattleScepter : Melee
    {
        public override int Dice => 1;

        public override int Sides => 6;

        public override int Add => 1;

        public override int AttributeCorrection => -2;

        public override int Weight => 2;

        public override int Value => 250;

        public override string Description => "Despite being rather unwieldy, this gold and gem encrusted scepter seems to have been used as a mace";

        public override string Name => "Scepter";

        public override Piercing Piercing => Piercing.Double;
    }
}
