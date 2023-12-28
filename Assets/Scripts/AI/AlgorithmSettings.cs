using System.Collections.Generic;

namespace AI
{
    public static class AlgorithmSettings
    {
        public static int PopulationSize = 10;
        public static int NumberOfItems = 50;
        public static int NumberOfGenerations = 10000;
        public static float MutationRate = 0.5f;
        public static float WeightLimit = 200;
        public static float MinWeight = 0.5f;
        public static float MaxWeight = 15f;
        public static float MinPrice = 0.5f;
        public static float MaxPrice = 50f;
        public static float WeightPenalty = 2f;
        
        public static readonly List<Item> Items = new List<Item>();
        public static float AllItemsTotalWeight = 0;
        public static float AllItemsTotalPrice = 0;
            

        public static void GenerateItems()
        {
            for (int i = 0; i < NumberOfItems; i++)
            {
                var randomItem = ItemFactory.CreateRandomItem();
                AllItemsTotalWeight+= randomItem.Weight;
                AllItemsTotalPrice+= randomItem.Price;
                Items.Add(randomItem);
            }
        }
    }
}