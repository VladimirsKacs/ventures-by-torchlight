using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentureCore;
using VentureCore.VendorTrash;
using VentureCore.Items;
using VentureCore.Enemies;

namespace Expeditions
{
    public class Expedition
    {

        public List<Item> Loot = new List<Item>();
        Random _random = new Random();

        public string Go(List<Adventurer> adventurers, Location location)
        {
            StringBuilder log = new StringBuilder();
            if (location == Location.Overgrown_Boss)
            {
                return Combat(adventurers, location);
            }

            for (var i = 0; i < _random.Next(4,8); i++)
            {
                switch (_random.Next(4))
                {
                    case 0:
                    case 1:
                        log.Append(Pickup(location));
                        break;
                    case 2:
                        log.Append(Chest(adventurers,location));
                        break;
                    case 3:
                        log.Append(Combat(adventurers, location));
                        break;
                }
            }

            return log.ToString();
        }

        string Combat(List<Adventurer> adventurers, Location location)
        {
            var sb = new StringBuilder();
            sb.Append("as you explore, you run into ");
            Combat combat;
            List<LootTable> loots= new List<LootTable>();
            switch (location)
            {
                case Location.Overgrown_1:
                case Location.Overgrown_2:
                    switch (_random.Next(7))
                    {
                        case 0:
                        case 1:
                        case 2:
                            combat = new Combat(adventurers, new List<Enemy> { new Rat(_random) {Count=1 }  }, _random.Next(75,125), _random);
                            loots.Add(new Rat((_random)).LootTable);
                            sb.AppendLine("a rat.");
                            break;
                        case 3:
                        case 4:
                        case 5:
                            combat = new Combat(adventurers, new List<Enemy> { new Slime(_random) { Count = 1 } }, _random.Next(75, 125), _random);
                            loots.Add(new Slime((_random)).LootTable);
                            sb.AppendLine("a green slime.");
                            break;
                        default:
                            combat = new Combat(adventurers, new List<Enemy> { new Rat(_random) { Count = 1 }, new Slime(_random) { Count = 1 } }, _random.Next(75, 125), _random);
                            loots.Add(new Rat((_random)).LootTable);
                            loots.Add(new Slime((_random)).LootTable);
                            sb.AppendLine("a rat and a green slime");
                            break;
                    }
                    break;
                case Location.Overgrown_3:
                case Location.Overgrown_4:
                    switch (_random.Next(7))
                    {
                        case 0:
                        case 1:
                            combat = new Combat(adventurers, new List<Enemy> { new Rat(_random) { Count = 1 } }, _random.Next(75, 125), _random);
                            loots.Add(new Rat((_random)).LootTable);
                            sb.AppendLine("a rat.");
                            break;
                        case 2:
                        case 3:
                            combat = new Combat(adventurers, new List<Enemy> { new Slime(_random) { Count = 1 } }, _random.Next(75, 125), _random);
                            loots.Add(new Slime((_random)).LootTable);
                            sb.AppendLine("a green slime.");
                            break;
                        case 4:
                        case 5:
                            combat = new Combat(adventurers, new List<Enemy> { new Cat(_random) { Count = 1 } }, _random.Next(75, 125), _random);
                            loots.Add(new Cat((_random)).LootTable);
                            sb.AppendLine("a feral cat.");
                            break;
                        default:
                            combat = new Combat(adventurers, new List<Enemy> { new Rat(_random) { Count = 1 }, new Slime(_random) { Count = 1 } }, _random.Next(75, 125), _random);
                            loots.Add(new Rat((_random)).LootTable);
                            loots.Add(new Slime((_random)).LootTable);
                            sb.AppendLine("a rat and a green slime");
                            break;
                    }
                    break;
                case Location.Overgrown_Boss:
                    combat = new Combat(adventurers, new List<Enemy> { new Wolf(_random) { Count = 1 } }, _random.Next(75, 125), _random);
                    loots.Add(new Wolf((_random)).LootTable);
                    sb.AppendLine("a large wolf");
                    break;
                default:
                    return String.Empty;
            }
            var result = combat.Fight();
            if (result == FightResult.Win)
            {
                sb.Append(combat.Log);
                sb.AppendLine("having defeated the enemy, you search their corpses.");
                var loot = new List<Item>();
                foreach (var l in loots)
                {
                    loot.AddRange(l.GetItems());
                }
                var separator = "";
                sb.Append("You find ");
                if (!loot.Any())
                    sb.Append("nothing");
                foreach (var l in loot)
                {
                    sb.Append(separator);
                    sb.Append(l.Name);
                    separator = ", ";
                }
                sb.AppendLine(".");
                Loot.AddRange(loot);
                return sb.ToString();
            }
            else if(result == FightResult.Draw)
            {
                sb.Append(combat.Log);
                sb.AppendLine("Exhausted by the fight, you leave each other alone.");
                return sb.ToString();
            }
            else
            {
                sb.Append(combat.Log);
                sb.AppendLine("YOU DIED.");
                return sb.ToString();
            }
            
        }


        string Pickup(Location location)
        {
            var sb = new StringBuilder();
            LootTable lootTable = null;
            switch (location)
            {
                case Location.Overgrown_1:
                case Location.Overgrown_2:
                    lootTable = new LootTable( new Dictionary<Item, int>
                    {
                        {new Nail(), 40},
                        {new SandPaper(), 30},
                        {new Pfennig(), 10 },
                        {new Groshen(), 5 },
                        {new Florin(), 1 },
                        {new Again(), 25 }
                    },_random);
                    sb.AppendLine("As you walk through the cave you notice something underfoot.");
                    sb.Append("You search through the dirt and find ");
                    break;
                case Location.Overgrown_3:
                case Location.Overgrown_4:
                    lootTable = new LootTable(new Dictionary<Item, int>
                    {
                        {new Nail(), 20},
                        {new SandPaper(), 15},
                        {new Pfennig(), 10 },
                        {new Groshen(), 5 },
                        {new Florin(), 1 },
                        {new ArenaTicket(), 1},
                        {new Again(), 25 }
                    }, _random);
                    sb.AppendLine("As you walk through the cave you notice something underfoot.");
                    sb.Append("You search through the dirt and find ");
                    break;
            }

            var loot = lootTable.GetItems();
            var separator = " a ";
            if (!loot.Any())
                sb.Append("nothing");
            foreach (var l in loot)
            {
                sb.Append(separator);
                sb.Append(l.Name);
                separator = ", a ";
            }
            sb.AppendLine(".");
            Loot.AddRange(loot);
            return sb.ToString();
        }

        string Chest(List<Adventurer> adventurers, Location location)
        {
            var sb = new StringBuilder();
            LootTable lootTable = null;
            switch (location)
            {
                case Location.Overgrown_1:
                    lootTable = new LootTable(new Dictionary<Item, int>
                    {
                        {new Nail(), 5},
                        {new SandPaper(), 1},
                        {new Pfennig(), 10 },
                        {new Groshen(), 5 },
                        {new Florin(), 1 },
                        {new Again(), 15 }
                    }, _random);
                    sb.AppendLine("You find a chest...");
                    break;
                case Location.Overgrown_2:
                    lootTable = new LootTable(new Dictionary<Item, int>
                    {
                        {new Nail(), 1},
                        {new SandPaper(), 5},
                        {new Pfennig(), 10 },
                        {new Groshen(), 5 },
                        {new Florin(), 1 },
                        {new Again(), 15 }
                    }, _random);
                    sb.AppendLine("You find a chest...");
                    break;
                case Location.Overgrown_3:
                    lootTable = new LootTable(new Dictionary<Item, int>
                    {
                        {new SandPaper(), 5},
                        {new Pfennig(), 10 },
                        {new Groshen(), 6 },
                        {new Florin(), 2 },
                        {new ArenaTicket(), 1 },
                        {new Again(), 15 }
                    }, _random);
                    sb.AppendLine("You find a chest...");
                    break;
                case Location.Overgrown_4:
                    lootTable = new LootTable(new Dictionary<Item, int>
                    {
                        {new Groshen(), 5 },
                        {new Florin(), 1 },
                        {new Again(), 10 }
                    }, _random);
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
                    sb.AppendLine("You attempt to pick the lock, but fail");
            }

            if (breaker != null && !success)
            {
                if (breaker.Strength > breakDifficulty)
                {
                    sb.Append("You break the lock and find ");
                    success = true;
                }
                else
                    sb.AppendLine("You attempt to break the lock, but it's too sturdy.");
            }
            if (success)
            {
                var loot = new List<Item>();
                for (var i =0; i<lootMultiplier; i++)
                {
                    loot.AddRange(lootTable.GetItems());
                }
                var separator = " a ";
                if (!loot.Any())
                    sb.Append("it empty");
                foreach (var l in loot)
                {
                    sb.Append(separator);
                    sb.Append(l.Name);
                    separator = ", a ";
                }
                sb.AppendLine(".");
                Loot.AddRange(loot);
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
