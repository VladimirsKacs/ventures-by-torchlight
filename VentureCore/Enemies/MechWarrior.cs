using System.Collections.Generic;
using VentureCore.Items;
using VentureCore.VendorTrash;
using VentureCore.Weapons;

namespace VentureCore.Enemies
{
    public class MechWarrior:Enemy
    {
        public MechWarrior()
        {
            Armor = 5;
            Strength = 13;
            Agility = 15;
            Dexterity = 13;
            MeleeDice = 2;
            MeleeSides = 3;
            MeleeName = "sabre attachment";
            MeleePiercing = Piercing.Half;
            RangeIncrement = 30;
            FiringRange = 119;
            Ammo = 10;
            RangedName = "gun attachment";
            RangedDice = 1;
            RangedSides = 6;
            RangedPiercing = Piercing.Half;
            Xp = 3000;
            Hp = HpMax = 35;
            Name = "Mechanical Warrior";
            LootTable = new LootTable( 
            new Dictionary<Item, int>{
                {new Cog(),16 },
                {new Spring(), 8 },
                {new MetalPlate(), 8 },
                {new Sabre(), 4 },
                {new Piston(), 1 },
                {new RifleBarrel(), 1},
                {new Again(), 50 }
            });
        }
    }
}
