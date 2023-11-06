using System.Collections.Generic;
using VentureCore.Items;
using VentureCore.VendorTrash;
using VentureCore.Weapons;

namespace VentureCore.Enemies
{
    public class MechSpitter:Enemy
    {
        public MechSpitter()
        {
            Armor = 2;
            Strength = 10;
            Agility = 15;
            Dexterity = 15;
            MeleeDice = 1;
            MeleeSides = 2;
            MeleeName = "ram";
            RangeIncrement = 25;
            FiringRange = 74;
            Ammo = 10;
            RangedName = "spike dart";
            RangedDice = 1;
            RangedSides = 4;
            RangedPiercing = Piercing.Half;
            Xp = 800;
            Hp = HpMax = 12;
            Name = "Mechanical Spitter";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new Cog(),8 },
                {new Spring(), 4 },
                {new MetalPlate(), 4 },
                {new Piston(), 2 },
                {new Again(), 13 }
            });
        }
    }
}
