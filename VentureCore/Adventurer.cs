using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Expeditions;

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
        public int Armor { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }

        public int Encumbrance
        {
            get
            {
                var sum = 0;
                foreach (var item in Items)
                {
                    sum += item.Weight;
                }
                return sum;
            }
        }

        public Melee Melee { get; set; }
        public Ranged Ranged { get; set; }

        public ObservableCollection<Item> Items { get; set; }

        public int FiringRange { get; set; }

        public int IdealRange { get; set; }

        public int HpThreshold { get; set; }

        public Row Row { get; set; }

        public string Print(int bid = 0)
        {
            var sb = new StringBuilder();
            sb.AppendLine("[table]");
            if(bid > 0)
                sb.AppendLine($"[tr][td][b]Entry Bid:[/b][/td][td]{bid/100.0}F[/td][td][/td][td][/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b][u]Name:[/u][/b][/td][td]{Name}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]HP (max):[/b][/td][td]{Hp}({HpMax})[/td][td]  |  [/td][td][b]Armor Class:[/b][/td][td]{Armor}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Strength:[/b][/td][td]{Strength}[/td][td]  |  [/td][td][b]Dexterity:[/b][/td][td]{Dexterity}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Constitution:[/b][/td][td]{Constitution}[/td][td]  |  [/td][td][b]Agility:[/b][/td][td]{Agility}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Level:[/b][/td][td]{Level}[/td][td]  |  [/td][td][b]XP:[/b][/td][td]{Xp}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Carry Capacity:[/b][/td][td]{CarryCapacity}[/td][td]  | [/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Melee:[/b][/td][td]{Melee?.Name ?? "Fists"}[/td][td]" +
                          $"  |  [/td][td][b]Ranged (ammo):[/b][/td][td]{Ranged?.Name ?? "N/A"} ({Ranged?.Ammo.ToString() ?? "N/A"})[/td][/tr]");
            sb.Append("[tr][td][/td][td][/td][td][b]Items:[/b][/td]");
            if (Items.Count == 0)
                sb.AppendLine("[td]None[/td][/tr]");
            else
                for (var i = 0; i <= (Items.Count - 1) / 2; i++)
                {
                    sb.Append($"[tr][td][/td][td][/td][td][/td][td]{Items[i * 2].Name}[/td]");
                    if (i * 2 + 1 >= Items.Count)
                        sb.AppendLine("[/tr]");
                    else
                        sb.AppendLine($"[td] |  [/td][td]{Items[i * 2 + 1].Name}[/td][/tr]");
                }
            sb.AppendLine("[/table]");
            return sb.ToString();
        }
    }
}
