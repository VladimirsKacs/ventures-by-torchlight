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
            new Backpack(),
            new LeatherArmor(),
            new PlateArmor()
        };
        public static List<Item> Consumables => new List<Item>
        {
            new HealthPotion(),
            new MicroHealthPotion(),
            new MinorHealthPotion(),
            new SpareAmmo()
        };

        public static List<Item> Weapons => new List<Item>
        {
            new Arquebus(),
            new Blunderbus(),
            new Crossbow(),
            new Dagger(),
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
