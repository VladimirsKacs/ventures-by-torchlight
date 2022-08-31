using System.Text;
using System.Windows.Controls;
using VentureCore.Items;

namespace Expeditions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VentureCore;
    using VentureCore.Weapons;
    class Combat
    {
        List<Adventurer> _adventurers;
        List<Enemy> _enemies;
        List<int> _advPositions;
        List<int> _enPositions;
        Random _random;

        public string Log => _log.ToString();
        readonly StringBuilder _log = new StringBuilder();

        Combat(List<Adventurer> adventurers, List<Enemy> enemies, int distance)
        {
            _adventurers = adventurers;
            _enemies = enemies;
            _advPositions= new List<int>();
            _enPositions= new List<int>();
            foreach (var adv in adventurers)
                _advPositions.Add(0);
            foreach (var enemy in enemies)
                _enPositions.Add(distance);
            _random = new Random();
        }

        public FightResult Fight()
        {
            return FightResult.Draw;
        }

        public void Round()
        {
            
        }

        public void StepA(int advIndex)
        {
            var adventurer = _adventurers[advIndex];
            if (adventurer.Hp < 0)
                return;
            var closestE = _enPositions.OrderBy(x => x).FirstOrDefault();
            var enIndex = _enPositions.Find(x => x == closestE); //TODO: better targeting
            var enemy = _enemies[enIndex];
            if (_advPositions[advIndex] == closestE)
            {
                var melee = adventurer.Melee ?? new Fists();
                _log.Append(adventurer.Name + " attacks " + enemy.Name + "with " + melee.Name);
                var roll = _random.Next(20);
                var adjustedArmor = enemy.Armor;
                switch (melee.Piercing)
                {
                    case Piercing.Double:
                        adjustedArmor = enemy.Armor * 2;
                        break;
                    case Piercing.Full:
                        adjustedArmor = 0;
                        break;
                    case Piercing.Half:
                        adjustedArmor = enemy.Armor / 2;
                        break;
                }

                var adjustedStrength = adventurer.Strength + melee.AttributeCorrection;
                if (roll < adjustedStrength && roll >= adjustedArmor)
                {
                    var damage = melee.Add;
                    for (var i = 0; i < melee.Dice; i++)
                        damage += _random.Next(melee.Sides) + 1;
                    _log.AppendLine("and hits for "+damage+" damage.");
                    enemy.Hp -= damage;
                    if (enemy.Hp <= 0)
                    {
                        enemy.Count -= 1;
                        enemy.Hp = enemy.HpMax;
                        if (enemy.Count > 0)
                            _log.AppendLine("One of the "+enemy.Name+"s dies. "+enemy.Count+" remain.");
                        else 
                            _log.Append(enemy.Name + " dies.");
                        if (enemy.Count == 0)
                        {
                            _enemies.Remove(enemy);
                            _enPositions.RemoveAt(enIndex);
                        }
                    }
                }
                else
                {
                    _log.AppendLine("but misses.");
                }
            }
            else
            {
                var movement = _random.Next(adventurer.Agility) + 1;
                var range = closestE - _advPositions[advIndex];
                if (adventurer.Ranged != null && adventurer.Ranged.Ammo > 0 && InRange(adventurer, range))
                {
                    movement = (movement + 1) / 2;
                    var ranged = adventurer.Ranged;
                    if (ranged.ReloadCooldown > 0)
                    {
                        ranged.ReloadCooldown--;
                        _log.AppendLine(adventurer.Name + " reloads.");
                    }
                    else
                    {
                        _log.Append(adventurer.Name + " attacks " + enemy.Name + "with " + ranged.Name + " from " + range + " feet ");
                        var roll = _random.Next(20);
                        var adjustedArmor = enemy.Armor;
                        switch (ranged.Piercing)
                        {
                            case Piercing.Double:
                                adjustedArmor = enemy.Armor * 2;
                                break;
                            case Piercing.Full:
                                adjustedArmor = 0;
                                break;
                            case Piercing.Half:
                                adjustedArmor = enemy.Armor / 2;
                                break;
                        }
                        var adjustedDexterity = adventurer.Dexterity + ranged.AttributeCorrection;
                        if (roll < adjustedDexterity && roll >= adjustedArmor)
                        {
                            var damage = ranged.Add;
                            for (var i = 0; i < ranged.Dice; i++)
                                damage += _random.Next(ranged.Sides) + 1;
                            _log.AppendLine("and hits for " + damage + " damage.");
                            enemy.Hp -= damage;
                            if (enemy.Hp <= 0)
                            {
                                enemy.Count -= 1;
                                enemy.Hp = enemy.HpMax;
                                if (enemy.Count > 0)
                                    _log.AppendLine("One of the " + enemy.Name + "s dies. " + enemy.Count + " remain.");
                                else
                                    _log.Append(enemy.Name + " dies.");
                                if (enemy.Count == 0)
                                {
                                    _enemies.Remove(enemy);
                                    _enPositions.RemoveAt(enIndex);
                                }
                            }
                        }
                        else
                        {
                            _log.AppendLine("but misses.");
                        }

                        ranged.Ammo--;
                        ranged.ReloadCooldown = ranged.Reload;
                        var ammo = adventurer.Items.OfType<SpareAmmo>().FirstOrDefault();
                        if (ranged.Ammo == 0 && ammo != null)
                        {
                            ranged.Ammo = ranged.AmmoMax;
                            adventurer.Items.Remove(ammo);
                        }
                    }
                }

                if (range > adventurer.IdealRange)
                {
                    if(range - movement<= adventurer.IdealRange)
                        movement = range - adventurer.IdealRange;
                    _advPositions[advIndex] += movement;
                    _log.AppendLine(adventurer.Name + " moves " + movement + " feet closer to " + enemy.Name + " (they are now " + (range - movement) + " feet apart.)" );
                }
                else if (range < adventurer.IdealRange)
                {
                    if (range + movement >= adventurer.IdealRange)
                        movement = adventurer.IdealRange - range;
                    _advPositions[advIndex] -= movement;
                    _log.AppendLine(adventurer.Name + " moves " + movement + " feet away from " + enemy.Name + " (they are now " + (range + movement) + " feet apart.)");
                }


            }
        }

        bool InRange(Adventurer adventurer, int distance)
        {
            return distance<adventurer.IdealRange; //TODO: better range
        }

    }
}
