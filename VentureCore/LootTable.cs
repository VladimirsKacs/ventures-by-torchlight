using System;
using System.Collections.Generic;
using System.Linq;
using VentureCore.VendorTrash;

namespace VentureCore
{
    public class LootTable
    {
        List<Tuple<Item, int>> _loot;
        int _sum;
        Random _random;

        public LootTable(Dictionary<Item,int> dic, Random random = null)
        {
            _sum = 0;
            _loot = new List<Tuple<Item, int>>();
            foreach (var kvp in dic)
            {
                _sum += kvp.Value;
                _loot.Add(new Tuple<Item,int>(kvp.Key, _sum));
            }
            _random = random ?? new Random();
        }

        public List<Item> GetItems()
        {
            var random = _random.Next(_sum);
            for (var i = 0; i < _loot.Count; i++)
                if (_loot[i].Item2 > random)
                {
                    if (_loot[i].Item1 == null)
                        return new List<Item>();
                    if (typeof(Again) == _loot[i].Item1.GetType())
                    {
                        var tmp = GetItems();
                        tmp.AddRange(GetItems());
                        return tmp;
                    }
                    return new List<Item> { _loot[i].Item1 };
                }
            return new List<Item>();
        }
    }
}
