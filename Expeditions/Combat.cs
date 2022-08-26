namespace Expeditions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VentureCore;
    class Combat
    {
        List<Adventurer> _adventurers;
        List<Enemy> _enemies;
        List<int> _advPositions;
        List<int> _enPositions;
        Random _random;

        public string Log;

        Combat(List<Adventurer> adventurers, List<Enemy> enemies, int distance)
        {
            _adventurers = adventurers;
            _enemies = enemies;
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
            if (_adventurers[advIndex].Hp < 0)
                return;
            var closestE = _enPositions.OrderBy(x => x).FirstOrDefault();
            if (_advPositions[advIndex] == closestE)
                ;
        }

    }
}
