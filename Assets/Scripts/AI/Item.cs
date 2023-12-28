using UnityEngine;

namespace AI
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
                Weight = Round(Random.Range(AlgorithmSettings.MinWeight, AlgorithmSettings.MaxWeight), 2),
                Price = Round(Random.Range(AlgorithmSettings.MinPrice, AlgorithmSettings.MaxPrice), 2)
            };
        }

        private static float Round(float value, int digits)
        {
            float mult = Mathf.Pow(10.0f, (float)digits);
            return Mathf.Round(value * mult) / mult;
        }
    }
}