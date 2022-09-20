﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VentureCore
{
    public abstract class Item
    {
        public abstract int Weight { get;}
        public abstract int Value { get;}

        public abstract string Description { get; }

        public abstract string Name { get; }
        public virtual void Equip(Adventurer adventurer)
        {
            if (adventurer.Encumbrance + Weight > adventurer.CarryCapacity)
                throw new Exception("too heavy");
            adventurer.Items.Add(this);
            adventurer.Encumbrance += Weight;
        }
        public virtual void Unequip(Adventurer adventurer)
        {
            if (!adventurer.Items.Contains(this))
                throw new Exception("not equipped");
            adventurer.Items.Remove(this);
            adventurer.Encumbrance -= Weight;
        }

        public new string ToString()
        {
            return Name;
        }

        public virtual string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine("[table]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b][u]Name:[/u][/b][/td][td]{Name}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Weight:[/b][/td][td]{Weight}[/td][td]  |  [/td][td][b]Value:[/b][/td][td]{Value}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Description:[/b][/td][td]{Description}[/td][td]");
            sb.AppendLine("[/table]");
            return sb.ToString();
        }
    }
}
