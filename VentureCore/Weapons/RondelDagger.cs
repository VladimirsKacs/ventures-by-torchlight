namespace VentureCore.Weapons
{
    public class RondelDagger : Melee
    {
        public override int Dice => 1;

        public override int Sides => 3;

        public override int Add => 0;

        public override int AttributeCorrection => 2;

        public override int Weight => 1;

        public override int Value => 100;

        public override string Description => "A dagger designed to pierce armor";

        public override string Name => "Rondel dagger";

        public override Piercing Piercing => Piercing.Full;
    }
}
