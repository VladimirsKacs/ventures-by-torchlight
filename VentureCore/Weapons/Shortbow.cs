namespace VentureCore.Weapons
{
    public class Shortbow : Ranged
    {
        public override int RangeIncrement => 30;

        public override int AmmoMax => 10;

        public override int Dice => 1;

        public override int Sides => 6;

        public override int Add => 0;

        public override int AttributeCorrection => -3;

        public override Piercing Piercing => Piercing.None;

        public override int Weight => 1;

        public override int Value => 150;

        public override string Description => "A short bow, used in hunting. Hard to use for the untrained.";

        public override string Name => "Short bow";

        public override int Reload => 0;
    }
}
