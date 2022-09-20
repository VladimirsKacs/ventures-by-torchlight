using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Melee:Weapon
    {
        public override void Equip(Adventurer adventurer)
        {
            base.Equip(adventurer);
            if (adventurer.Melee != null)
                adventurer.Melee.Unequip(adventurer);
            adventurer.Melee = this;
        }

        public override void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Melee = null;
        }

        public override string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine("[table]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b][u]Name:[/u][/b][/td][td]{Name}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Weight:[/b][/td][td]{Weight}[/td][td]  |  [/td][td][b]Damage:[/b][/td][td]{Dice}d{Sides}+{Add}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Value:[/b][/td][td]{Value}[/td][td]  |  [/td][td][b]Attribute Correction:[/b][/td][td]{AttributeCorrection}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Description:[/b][/td][td]{Description}[/td][td] |  [/td][td][b]Piercing:[/b][/td][td]{Piercing}[/td][/tr]");
            sb.AppendLine("[/table]");
            return sb.ToString();
        }
    }
}
