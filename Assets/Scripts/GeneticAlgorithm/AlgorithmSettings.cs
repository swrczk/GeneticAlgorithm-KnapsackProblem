using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public static class AlgorithmSettings
    {
        public static int PopulationSize = 100;
        public static int NumberOfItems = 100;
        public static int NumberOfGenerations = 100;
        public static float MutationRate = 0.5f;
        public static float WeightLimit = 10;
        public static float MinWeight = 0.5f;
        public static float MaxWeight = 1f;
        public static float MinPrice = 0.5f;
        public static float MaxPrice = 1f;
        
        public static List<Item> Items = new List<Item>();

        public static void GenerateItems()
        {
            for (int i = 0; i < NumberOfItems; i++)
            {
                Items.Add(ItemFactory.CreateRandomItem());
            }
        }
    }
}