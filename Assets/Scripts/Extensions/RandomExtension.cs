using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Extensions
{
    public static class RandomExtension
    {
        public static T GetRandomItem<T>(this IEnumerable<T> list, Func<T, float> exucator)
        {
            var sum = list.Sum(it => exucator(it));
            var randomPoint = Random.value * sum;
            foreach (var item in list)
            {
                var chance = exucator(item);
                if (chance > randomPoint)
                    return item;
                
                randomPoint -= chance;
            }

            return list.Last();
        }
    }
}