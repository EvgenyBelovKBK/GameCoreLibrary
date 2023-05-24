﻿using GameCoreLibrary.Enums;
using GameCoreLibrary.Interfaces;

namespace GameCoreLibrary.Services
{
    public class ThingRandomGenerator<T> : NumbersRandomGenerator where T:ITierable
    {

        public ThingRandomGenerator( )
        {

        }

        /// <summary>
        /// Получает словарь - тир = кол-во штук этого тира
        /// </summary>
        /// <param name="totalAmount">кол-во штук</param>
        /// <param name="chancesDictionary">тир = шанс</param>
        /// <returns></returns>
        public Dictionary<Tiers, int> GetThingsCountInTiers(int totalAmount, Dictionary<Tiers, int> chancesDictionary)
        {
            var result = new Dictionary<Tiers, int>(){{Tiers.Tier1,0}, { Tiers.Tier2, 0 }, { Tiers.Tier3, 0 }, { Tiers.Tier4, 0 }, { Tiers.Tier5, 0 }};

            var currentAmount = 0;
            while (currentAmount < totalAmount)
            {
                foreach (var chancePair in chancesDictionary)
                {
                    if(currentAmount == totalAmount)
                        break;
                    if (IsRolled(chancePair.Value))
                    {
                        result[chancePair.Key]++;
                        currentAmount++;
                    }
                }
            }
            return result;
        }

        public List<T> GenerateRandomThings(T[] thingsEnumerable,Tiers tier, int itemsCount, Dictionary<Tiers, int> chancesDictionary)
        {
            var items = new List<T>();
            var itemsTiersCount = GetThingsCountInTiers(itemsCount, chancesDictionary);
            foreach (var currentTier in itemsTiersCount)
            {
                var currentTierList = new List<T>(thingsEnumerable.Where(x => x.Tier == currentTier.Key)).ToArray();
                var minIndex = 0;
                var maxIndex = 0;
                if (currentTierList.Length > 0)
                {
                    minIndex = Array.IndexOf(currentTierList, currentTierList.First());
                    maxIndex = Array.IndexOf(currentTierList, currentTierList.Last());
                }
                var indexes = new List<int>();
                for (int i = 0; i < currentTier.Value; i++)
                {
                    var randomIndex = GetRandomNumber(minIndex, maxIndex);
                    while (indexes.Contains(randomIndex))
                    {
                        randomIndex = GetRandomNumber(minIndex, maxIndex);
                    }
                    items.Add(currentTierList.ElementAt(randomIndex));
                    indexes.Add(randomIndex);
                }
            }
            return items;
        }
    }
}
