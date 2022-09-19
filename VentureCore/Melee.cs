using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Melee:Weapon
    {
        override public void Eqiup(Adventurer adventurer)
        {
            base.Eqiup(adventurer);
            if (adventurer.Melee != null)
                adventurer.Melee.Unequip(adventurer);
            adventurer.Melee = this;
        }

        override public void Unequip(Adventurer adventurer)
        {
            base.Unequip(adventurer);
            adventurer.Melee = null;
        }

        new public string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine("[table]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b][u]Name:[/u][/b][/td][td]{Name}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Weight:[/b][/td][td]{Weight})[/td][td]  |  [/td][td][b]Damage:[/b][/td][td]{Dice}d{Sides}+{Add}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Value:[/b][/td][td]{Value}[/td][td]  |  [/td][td][b]Attribute Correction:[/b][/td][td]{AttributeCorrection}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Description:[/b][/td][td]{Description}[/td][td]");
            sb.AppendLine("[/table]");
            return sb.ToString();
        }
    }
}
