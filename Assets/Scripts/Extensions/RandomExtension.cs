using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Extensions
{
    public static class RandomExtension
    {
        public static T GetRandomItem<T>(this IEnumerable<T> list, Func<T, float> executor)
        {
            var sum = list.Sum(executor);
            var randomPoint = Random.value * sum;
            foreach (var item in list)
            {
                var chance = executor(item);
                if (chance > randomPoint)
                    return item;
                
                randomPoint -= chance;
            }

            return list.Last();
        }

        public static bool CheckProbability(float chance, float fullProgress)
        {
            var probabilities = new[]
            {
                chance,
                fullProgress - chance
            };

            var result = probabilities.GetRandomItem(ch => ch);
            return Math.Abs(result - chance) < 0.1f;
        }
    }
}