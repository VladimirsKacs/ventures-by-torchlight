using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentureCore;
using VentureCore.VendorTrash;
using VentureCore.Items;

namespace Expeditions
{
    public class Expedition
    {

        public List<Item> Loot = new List<Item>();

        public string Go(List<Adventurer> adventurers, Location location)
        {
            StringBuilder log = new StringBuilder();

            return log.ToString();
        }

        string Combat(List<Adventurer> adventurers, Location location)
        {

        }


        string Pickup(Location location)
        {
            var sb = new StringBuilder();
            LootTable lootTable = null;
            switch (location)
            {
                case Location.Basic_1:
                    lootTable = new LootTable( new Dictionary<Item, int>
                    {
                        {new Nail(), 40},
                        {new SandPaper(), 30},
                        {new Pfennig(), 10 },
                        {new Groshen(), 5 },
                        {new Florin(), 1 },
                        {new Again(), 10 }
                    });
                    sb.Append("You search through the trash and find ");
                    break;
            }

            var loot = lootTable.GetItems();
            var separator = "";
            if (!loot.Any())
                sb.Append("nothing");
            foreach (var l in loot)
            {
                sb.Append(separator);
                sb.Append(l.Name);
                separator = ", ";
            }
            sb.AppendLine(".");
            Loot=Loot.Concat(loot).ToList();
            return sb.ToString();
        }

        string Chest(List<Adventurer> adventurers, Location location)
        {
            var sb = new StringBuilder();
            LootTable lootTable = null;
            switch (location)
            {
                case Location.Basic_1:
                    lootTable = new LootTable(new Dictionary<Item, int>
                    {
                        {new Nail(), 5},
                        {new SandPaper(), 1},
                        {new Pfennig(), 10 },
                        {new Groshen(), 5 },
                        {new Florin(), 1 },
                        {new Again(), 5 }
                    });
                    sb.AppendLine("You find a chest...");
                    break;
            }

            Random random = new Random();
            var pickDifficulty = random.Next(20);
            var breakDifficulty = random.Next(20);
            var lootMultiplier = (pickDifficulty + breakDifficulty) / 5;

            var picker = adventurers.Where(a => a.Items.OfType<LockPick>().Any()).OrderBy(a => a.Dexterity).LastOrDefault();
            var breaker = adventurers.Where(a => a.Items.OfType<Crowbar>().Any()).OrderBy(a => a.Strength).LastOrDefault();

            if(picker == null && breaker == null)
            {
                sb.AppendLine("You ignore it, due to having no tools");
                return sb.ToString();
            }
            var success = false;
            if (picker != null)
            {
                if (picker.Dexterity > pickDifficulty)
                {
                    sb.Append("You pick the lock and find ");
                    success = true;
                }
                else
                    sb.AppendLine("You attmept to pick the lock, but fail");
            }

            if (breaker != null && !success)
            {
                if (breaker.Strength > breakDifficulty)
                {
                    sb.Append("You break the lock and find ");
                    success = true;
                }
                else
                    sb.AppendLine("You attmept to break the lock, but it's too sturdy.");
            }
            if (success)
            {
                var loot = new List<Item>();
                for (var i =0; i<lootMultiplier; i++)
                {
                    loot.Concat(lootTable.GetItems()).ToList();
                }
                var separator = "";
                if (!loot.Any())
                    sb.Append("it empty");
                foreach (var l in loot)
                {
                    sb.Append(separator);
                    sb.Append(l.Name);
                    separator = ", ";
                }
                sb.AppendLine(".");
                Loot = Loot.Concat(loot).ToList();
                return sb.ToString();
            }
            else
            {
                sb.AppendLine("You leave empty handed.");
                return sb.ToString();
            }
        }
    }
}
