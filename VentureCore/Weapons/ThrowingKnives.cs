namespace VentureCore.Weapons
{
    public class ThrowingKnives : Ranged
    {
        public override int RangeIncrement => 10;

        public override int AmmoMax => 3;

        public override int Dice => 1;

        public override int Sides => 3;

        public override int Add => 0;

        public override int AttributeCorrection => -1;

        public override Piercing Piercing => Piercing.None;

        public override int Weight => 1;

        public override int Value => 50;

        public override string Description => "Well balanced throwing knives";

        public override string Name => "Throwing knives";

        public override int Reload => 0;
    }
}
