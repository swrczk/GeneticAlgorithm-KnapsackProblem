using UnityEngine;

namespace GeneticAlgorithm
{
    public class Item
    {
        public float Weight { get; set; }
        public float Price { get; set; }
    }

    public abstract class ItemFactory
    {
        public static Item CreateRandomItem()
        {
            return new Item
            {
                Weight = Random.Range(AlgorithmSettings.MinWeight, AlgorithmSettings.MaxWeight),
                Price = Random.Range(AlgorithmSettings.MinPrice, AlgorithmSettings.MaxPrice)
            };
        }
    }
}