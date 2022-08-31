namespace VentureCore.Weapons
{
    public class Rapier : Melee
    {
        public override int Dice => 1;

        public override int Sides => 5;

        public override int Add => 0;

        public override int AttributeCorrection => 1;

        public override int Weight => 1;

        public override int Value => 200;

        public override string Description => "A long, thin sword, designed to pierce armor";

        public override string Name => "Rapier";

        public override Piercing Piercing => Piercing.Half;
    }
}
