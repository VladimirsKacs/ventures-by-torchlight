namespace VentureCore.Weapons
{
    public class NailStick : Melee
    {
        public override int Dice => 1;

        public override int Sides => 6;

        public override int Add => 0;

        public override int AttributeCorrection => -1;

        public override int Weight => 1;

        public override int Value => 50;

        public override string Description => "A stick with rusty nails coming out of it";

        public override string Name => "Stick with nails";

        public override Piercing Piercing => Piercing.Double;
    }
}
