using System.Collections.Generic;
using System.Linq;
using VentureCore.Items;
using VentureCore.Weapons;

namespace VentureCore
{
    public class AllItems
    {
        public static List<Item> Items => new List<Item>
        {
            new AdvancedLockPick(),
            new Backpack(),
            new Chainmail(),
            new Crowbar(),
            new HideArmor(),
            new HydraulicSpreader(),
            new LeatherArmor(),
            new LockPick(),
            new PlateArmor(),
            new UnderArmor(),
        };
        public static List<Item> Consumables => new List<Item>
        {
            new Buffout(),
            new HealthPotion(),
            new MicroHealthPotion(),
            new MinorHealthPotion(),
            new SpareAmmo(),
            new LongHealthPotion(),
            new Whiskey()
        };

        public static List<Item> Weapons => new List<Item>
        {
            new Arquebus(),
            new Blunderbus(),
            new Crossbow(),
            new CrudeSpear(),
            new Dagger(),
            new Flintlock(),
            new Longbow(),
            new LongSword(),
            new NailStick(),
            new Rapier(),
            new RondelDagger(),
            new RustyDagger(),
            new Shortbow(),
            new ShortSword(),
            new Stick(),
            new ThrowingAxe(),
            new ThrowingKnives()
        };

        public static List<Item> All => Items.Concat(Consumables).Concat(Weapons).ToList();

    }
}
