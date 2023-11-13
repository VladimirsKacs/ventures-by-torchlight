namespace VentureCore.Weapons
{
    public class Flintlock : Ranged
    {
        public override int RangeIncrement => 75;

        public override int AmmoMax => 4;

        public override int Dice => 1;

        public override int Sides => 6;

        public override int Add => 2;

        public override int AttributeCorrection => 2;

        public override Piercing Piercing => Piercing.Full;

        public override int Weight => 3;

        public override int Value => 600;

        public override string Description => "A fully assembled precursor artifact, similar in function to an arquebus, but much more accurate";

        public override string Name => "Flintlock rifle";

        public override int Reload => 3;
    }
}
