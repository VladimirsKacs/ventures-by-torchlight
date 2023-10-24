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
        static Random _random = new Random();

        public LootTable(Dictionary<Item,int> dic)
        {
            _sum = 0;
            _loot = new List<Tuple<Item, int>>();
            foreach (var kvp in dic)
            {
                _sum += kvp.Value;
                _loot.Add(new Tuple<Item,int>(kvp.Key, _sum));
            }
        }

        public List<Item> GetItems(int depth = 0)
        {
            List<Item> loot;
            Item item= new Again();
            do
            {
                var random = _random.Next(_sum);
                for (var i = 0; i < _loot.Count; i++)
                    if (_loot[i].Item2 > random)
                    {
                        item = _loot[i].Item1;
                        break;
                    }
            } while (depth >= 4 && typeof(Again) == item.GetType());
            if(typeof(Again) == item.GetType() )
            {
                loot = GetItems(depth + 1);
                loot.AddRange(GetItems(depth + 1));
                return loot;
            }
            return new List<Item> { item };
        }
    }
}
