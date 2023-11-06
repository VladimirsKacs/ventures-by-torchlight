using VentureCore.Buffs;

namespace VentureCore.Items
{
    public class Buffout : Consumable
    {
        public override int Weight => 1;

        public override int ChargesMax => 2;
        public override string Name => "Buffout";
        public override string Description => "A popular drug used by laborers and soldiers alike to increase strength and resist fatigue. Side effects include lowered resistance to poisons. (Improves Strength by 2 for the day, but reduces Costitution by the same amount. Does not cause loss of HP)";

        public override int Value => 100;

        public override void Use(Adventurer adventurer)
        {
            base.Use(adventurer);
            new Buffed().Apply(adventurer);
        }
    }
}
