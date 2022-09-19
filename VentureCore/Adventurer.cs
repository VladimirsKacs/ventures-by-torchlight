using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public class Adventurer
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Hp { get; set; }
        public int HpMax { get; set; }
        public int Agility { get; set; }
        public int CarryCapacity { get; set; }
        public int Servitude { get; set; }
        public int Armor { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public int Encumbrance { get; set; }

        public Melee Melee { get; set; }
        public Ranged Ranged { get; set; }

        public List<Item> Items { get; set; }

        public int FiringRange { get; set; }

        public int IdealRange { get; set; }

        public string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine("[table]");
            sb.AppendLine("[tr][td][b]Entry Bid:[/b][/td][td]3F[/td][td][/td][td][/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b][u]Name:[/u][/b][/td][td]{Name}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]HP (max):[/b][/td][td]{Hp}({HpMax})[/td][td]  |  [/td][td][b]Armor Class:[/b][/td][td]{Armor}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Strength:[/b][/td][td]{Strength}[/td][td]  |  [/td][td][b]Dexterity:[/b][/td][td]{Dexterity}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Constitution:[/b][/td][td]{Constitution}[/td][td]  |  [/td][td][b]Agility:[/b][/td][td]{Agility}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Level:[/b][/td][td]{Level}[/td][td]  |  [/td][td][b]XP:[/b][/td][td]{Xp}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Carry Capacity:[/b][/td][td]{CarryCapacity}[/td][td]  |  [/td][td][b]Service Length:[/b][/td][td]{Servitude}[/td][/tr]");
            sb.AppendLine("[/table]");
            return sb.ToString();
        }
    }
}
