using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Consumable:Item
    {
        public int Charges { get; set; }
        public abstract int ChargesMax { get;}

        public void Use(Adventurer adventurer)
        {
            Charges--;
            if (Charges == 0)
                Unequip(adventurer);
        }

        public new void Equip(Adventurer adventurer)
        {
            base.Equip(adventurer);
            Charges = ChargesMax;
        }

        public override string Print(int count = 0)
        {
            var sb = new StringBuilder();
            sb.AppendLine("[table]");
            if (count > 0)
            {
                var rand = new Random();
                sb.AppendLine($"[tr][td][b]Price:[/b][/td][td]{rand.Next(Value, Value * 2) / 100.0}F[/td][/tr]");
                sb.AppendLine($"[td][b]Stock:[/b][/td][td]{count}[/td][/tr]");
            }
            sb.AppendLine($"[tr][td][/td][td][/td][td][b][u]Name:[/u][/b][/td][td]{Name}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Weight:[/b][/td][td]{Weight})[/td][td]  |  [/td][td][b]Charges:[/b][/td][td]{ChargesMax}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Value:[/b][/td][td]{Value}[/td][td]  |  [/td][td][b]Consumable:[/b][/td][td]Yes[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Description:[/b][/td][td]{Description}[/td][td][/tr]");
            sb.AppendLine("[/table]");
            return sb.ToString();
        }
    }
}
