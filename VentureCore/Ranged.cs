using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Ranged:Weapon
    {
        public abstract int RangeIncrement { get;}
        public int Ammo { get; set; }
        public abstract int AmmoMax { get;}

        public abstract int Reload { get; }
        public int ReloadCooldown { get; set; }

        public override void Equip(Adventurer adventurer)
        {
            base.Equip(adventurer);
            if (adventurer.Ranged != null)
                adventurer.Ranged.Unequip(adventurer);
            adventurer.Ranged = this;
            Ammo = AmmoMax;
        }

        public override void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Ranged = null;
        }

        public override string Print(int count = 0)
        {
            var sb = new StringBuilder();
            sb.AppendLine("[table]");
            if (count > 0)
            {
                sb.AppendLine($"[tr][td][b]Price:[/b][/td][td]{rand.Next(Value, Value * 2) / 100.0}F[/td][/tr]");
                sb.AppendLine($"[td][b]Stock:[/b][/td][td]{count}[/td][/tr]");
            }
            sb.AppendLine($"[tr][td][/td][td][/td][td][b][u]Name:[/u][/b][/td][td]{Name}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Weight:[/b][/td][td]{Weight}[/td][td]  |  [/td][td][b]Damage:[/b][/td][td]{Dice}d{Sides}+{Add}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Value:[/b][/td][td]{Value}[/td][td]  |  [/td][td][b]Attribute Correction:[/b][/td][td]{AttributeCorrection}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]AmmoMax:[/b][/td][td]{AmmoMax}[/td][td]  |  [/td][td][b]Range Increment:[/b][/td][td]{RangeIncrement}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Reload:[/b][/td][td]{Reload}[/td][td]  |  [/td][td][b]Piercing:[/b][/td][td]{Piercing}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Description:[/b][/td][td]{Description}[/td][td][/tr]");
            sb.AppendLine("[/table]");
            return sb.ToString();
        }
    }
}
