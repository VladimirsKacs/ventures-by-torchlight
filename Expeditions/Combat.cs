﻿using System.Text;
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
        readonly List<Adventurer> _adventurers;
        readonly List<Enemy> _enemies;
        readonly List<int> _advPositions;
        readonly List<int> _enPositions;
        readonly Random _random;

        public string Log => _log.ToString();
        readonly StringBuilder _log = new StringBuilder();

        public Combat(List<Adventurer> adventurers, List<Enemy> enemies, int distance, Random random = null)
        {
            _adventurers = adventurers;
            _enemies = enemies;
            _advPositions= new List<int>();
            _enPositions= new List<int>();
            foreach (var adv in adventurers)
            {
                _advPositions.Add(0);
                if (adv.Ranged != null)
                    adv.Ranged.ReloadCooldown = 0;
            }

            foreach (var enemy in enemies)
                _enPositions.Add(distance);
            _random = random ?? new Random();
        }

        public FightResult Fight()
        {
            var i = 0;
            while (_adventurers.Any() && _enemies.Any() && i++ < 100)
            {
                Round();
            }
            if(!_adventurers.Any())
                return FightResult.Lose;
            if (!_enemies.Any())
                return FightResult.Win;
            return FightResult.Draw;
        }

        void Round()
        {
            for (int i = 0; i < _adventurers.Count; i++)
                StepA(i);
            for (int i = 0; i < _enemies.Count; i++)
                StepE(i);
        }

        void StepA(int advIndex)
        {
            var adventurer = _adventurers[advIndex];
            if (_enemies.Count == 0)
                return;
            var closestE = _enPositions.OrderBy(x => x).FirstOrDefault();
            var enIndex = _enPositions.IndexOf(closestE); //TODO: better targeting
            var enemy = _enemies[enIndex];

            var movement = _random.Next(adventurer.Agility/2, adventurer.Agility) + 1;
            var range = closestE - _advPositions[advIndex];
            var attackable = false;
            if (_advPositions[advIndex] != closestE)
            {
                if ((!adventurer.HoldFire && adventurer.Ranged != null && adventurer.Ranged.Ammo > 0 && InRange(adventurer, range))
                    || (range < (movement + 1) / 2))
                {
                    movement = (movement + 1) / 2;
                    attackable = true;
                }

                var leader = _adventurers.FirstOrDefault(x => x.Row == Row.Leader && x != adventurer);
                var guardian = _adventurers.FirstOrDefault(x => x.Row == Row.First || x.Row == Row.Leader);
                if (leader != null && adventurer.Row == Row.First && range > adventurer.IdealRange)
                {
                    var lIndex = _adventurers.IndexOf(leader);
                    var lPosition = _advPositions[lIndex];
                    if (lPosition - movement < _advPositions[advIndex])
                        movement = lPosition - _advPositions[advIndex];
                    _advPositions[advIndex] += movement;
                    _log.AppendLine(
                        $"{adventurer.Name} stays behind {leader.Name}. They are now {_advPositions[lIndex] - _advPositions[advIndex]} feet apart.");
                }
                else if (guardian != null && adventurer.Row == Row.Last && range > adventurer.IdealRange)
                {
                    var gIndex = _adventurers.IndexOf(guardian);
                    var gPosition = _advPositions[gIndex] - 1;
                    if (gPosition - movement < _advPositions[advIndex])
                        movement = gPosition - _advPositions[advIndex];
                    _advPositions[advIndex] += movement;
                    _log.AppendLine(
                        $"{adventurer.Name} stays behind {guardian.Name}. They are now {_advPositions[gIndex] - _advPositions[advIndex]} feet apart.");
                }
                else
                {
                    if (range > adventurer.IdealRange)
                    {
                        if (range - movement <= adventurer.IdealRange)
                            movement = range - adventurer.IdealRange;
                        _advPositions[advIndex] += movement;
                        _log.AppendLine(adventurer.Name + " moves " + movement + " feet closer to " + enemy.Name +
                                        " (they are now " + (range - movement) + " feet apart.)");
                    }
                    else if (range < adventurer.IdealRange)
                    {
                        if (range + movement >= adventurer.IdealRange)
                            movement = adventurer.IdealRange - range;
                        _advPositions[advIndex] -= movement;
                        _log.AppendLine(adventurer.Name + " moves " + movement + " feet away from " + enemy.Name +
                                        " (they are now " + (range + movement) + " feet apart.)");
                    }
                }
            }
            else
            {
                attackable = true;
            }

            if(attackable)
                if (_advPositions[advIndex] == closestE)
                {
                    var melee = adventurer.Melee ?? new Fists();
                    _log.Append(adventurer.Name + " attacks " + enemy.Name + " with " + melee.Name);
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

                    var adjustedStrength = adventurer.Strength + melee.AttributeCorrection - adjustedArmor;
                    if (roll < adjustedStrength)
                    {
                        var damage = melee.Add;
                        for (var i = 0; i < melee.Dice; i++)
                            damage += _random.Next(melee.Sides) + 1;
                        _log.AppendLine(" and hits for " + damage + " damage.");
                        enemy.Hp -= damage;
                        CheckDead(enemy, enIndex);
                    }
                    else
                    {
                        _log.AppendLine(" but misses.");
                    }
                }
                else
                {
                    range = closestE - _advPositions[advIndex];
                    if (!adventurer.HoldFire && adventurer.Ranged != null && adventurer.Ranged.Ammo > 0 && InRange(adventurer, range))
                    {
                        var ranged = adventurer.Ranged;
                        if (ranged.ReloadCooldown > 0)
                        {
                            ranged.ReloadCooldown--;
                            _log.AppendLine(adventurer.Name + " reloads.");
                        }
                        else
                        {
                            _log.Append(adventurer.Name + " attacks " + enemy.Name + " with " + ranged.Name + " from " + range + " feet ");
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

                            var rangeIncrements = range / ranged.RangeIncrement;
                            var adjustedDexterity = adventurer.Dexterity + ranged.AttributeCorrection - rangeIncrements - adjustedArmor;
                            if (roll < adjustedDexterity)
                            {
                                var damage = ranged.Add;
                                for (var i = 0; i < ranged.Dice; i++)
                                    damage += _random.Next(ranged.Sides) + 1;
                                _log.AppendLine("and hits for " + damage + " damage.");
                                enemy.Hp -= damage;
                                CheckDead(enemy, enIndex);
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
                                _log.AppendLine($"{adventurer.Name} unpacks his spare ammo.");
                                ranged.Ammo = ranged.AmmoMax;
                                ammo.Unequip(adventurer);
                            }
                        }
                    }

                    if (adventurer.Ranged == null || adventurer.Ranged.Ammo <= 0 || adventurer.HoldFire)
                        adventurer.IdealRange = 0;
                }
        }

        void StepE(int eIndex)
        {
            var enemy = _enemies[eIndex];
            if (_adventurers.Count == 0)
                return;
            var closestA = _advPositions.OrderBy(x => x).LastOrDefault();
            var advIndex = _advPositions.IndexOf(closestA); //TODO: better targeting
            var adv = _adventurers[advIndex];

            var movement = _random.Next(enemy.Agility/2, enemy.Agility) + 1;
            var range = _enPositions[eIndex] - closestA;
            var attackable = false;
            if (_enPositions[eIndex] == closestA)
                attackable = true;
            else
            {
                if ((enemy.Ammo > 0 && InRange(enemy, range)) || range <= (movement + 1) / 2)
                {
                    movement = (movement + 1) / 2;
                    attackable = true;
                }

                if (_enPositions[eIndex] - movement > closestA)
                    _enPositions[eIndex] -= movement;
                else
                {
                    movement = _enPositions[eIndex] - closestA;
                    _enPositions[eIndex] = closestA;
                }

                if (movement > 0)
                    _log.AppendLine(enemy.Name + " moves " + movement + " feet closer to " + adv.Name +
                                    " (they are now " + (range - movement) + " feet apart.)");
            }

            if (attackable)
                if (_enPositions[eIndex] == closestA)
                {
                    _log.Append(enemy.Name + " attacks " + adv.Name + " with " + enemy.MeleeName);
                    var roll = _random.Next(20);
                    var adjustedArmor = adv.Armor;
                    switch (enemy.MeleePiercing)
                    {
                        case Piercing.Double:
                            adjustedArmor = adjustedArmor * 2;
                            break;
                        case Piercing.Full:
                            adjustedArmor = 0;
                            break;
                        case Piercing.Half:
                            adjustedArmor = adjustedArmor / 2;
                            break;
                    }
                    var adjustedStrength = enemy.Strength - adjustedArmor;
                    if (roll < adjustedStrength)
                    {
                        var damage = enemy.MeleeAdd;
                        for (var i = 0; i < enemy.MeleeDice; i++)
                            damage += _random.Next(enemy.MeleeSides) + 1;
                        _log.AppendLine(" and hits for " + damage + " damage.");
                        adv.Hp -= damage;
                        if (enemy.OffensiveBuff != null && adv.Constitution<_random.Next(20))
                        {
                            enemy.OffensiveBuff.Apply(adv);
                            _log.AppendLine($"{enemy.Name} applies {enemy.OffensiveBuff.Name} to {adv}");
                        }
                        if (adv.Hp <= 0)
                        {
                            _log.AppendLine($"{adv.Name} dies.");
                            _adventurers.Remove(adv);
                            _advPositions.RemoveAt(advIndex);
                        }
                    }
                    else
                    {
                        _log.AppendLine(" but misses.");
                    }
                }
                else
                {
                    range = _enPositions[eIndex] - closestA;
                    if (enemy.Ammo > 0 && InRange(enemy, range))
                    {
                        _log.Append(enemy.Name + " attacks " + adv.Name + " with " + enemy.RangedName + " from " + range + " feet ");
                        var roll = _random.Next(20);
                        var adjustedArmor = adv.Armor;
                        switch (enemy.RangedPiercing)
                        {
                            case Piercing.Double:
                                adjustedArmor = adjustedArmor * 2;
                                break;
                            case Piercing.Full:
                                adjustedArmor = 0;
                                break;
                            case Piercing.Half:
                                adjustedArmor = adjustedArmor / 2;
                                break;
                        }
                        var rangeIncrements = range / enemy.RangeIncrement;
                        var adjustedDexterity = enemy.Dexterity - rangeIncrements - adjustedArmor;
                        if (roll < adjustedDexterity)
                        {
                            var damage = enemy.RangedAdd;
                            for (var i = 0; i < enemy.RangedDice; i++)
                                damage += _random.Next(enemy.RangedSides) + 1;
                            _log.AppendLine(" and hits for " + damage + " damage.");
                            adv.Hp -= damage;
                            if (enemy.OffensiveBuff != null)
                            {
                                enemy.OffensiveBuff.Apply(adv);
                                _log.AppendLine($"{enemy.Name} applies {enemy.OffensiveBuff.Name} to {adv}");
                            }
                            if (adv.Hp <= 0)
                            {
                                _log.AppendLine($"{adv.Name} dies.");
                                _adventurers.Remove(adv);
                                _advPositions.RemoveAt(advIndex);
                            }
                        }
                        else
                        {
                            _log.AppendLine(" but misses.");
                        }

                        enemy.Ammo--;
                    }
                }
        }

        void CheckDead (Enemy enemy, int eIndex)
        {
            if (enemy.Hp <= 0)
            {
                _log.AppendLine(enemy.Name + " dies.");
                _enemies.Remove(enemy);
                _enPositions.RemoveAt(eIndex);
                AwardXp(enemy);
            }
        }

        void AwardXp(Enemy enemy)
        {
            var xp = enemy.Xp / _adventurers.Count;
            foreach (var adv in _adventurers)
                adv.Xp += xp;
        }

        bool InRange(Adventurer adventurer, int distance)
        {
            return distance <=  adventurer.FiringRange; //TODO: better range
        }

        bool InRange(Enemy enemy, int distance)
        {
            return distance <= enemy.FiringRange; //TODO: better range
        }

    }
}
