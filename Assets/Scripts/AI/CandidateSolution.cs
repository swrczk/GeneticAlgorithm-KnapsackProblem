using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class CandidateSolution
    {
        public float Fitness { get; private set; }
        public List<bool> Genes { get; set; }
        public float TotalPrice { get; set; }
        public float TotalWeight { get; set; }

        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            for (int i = 0; i < Genes.Count; i++)
            {
                if (Genes[i])
                {
                    items.Add(AlgorithmSettings.Items[i]);
                }
            }

            return items;
        }

        public static CandidateSolution Initialize()
        {
            CandidateSolution solution = new CandidateSolution();
            solution.Genes = new List<bool>(AlgorithmSettings.NumberOfItems);
            for (int j = 0; j < AlgorithmSettings.NumberOfItems; j++)
            {
                solution.Genes.Add(Random.value < 0.5f);
            }

            solution.CalculateFitness();
            return solution;
        }

        public void Mutate()
        {
            for (int i = 0; i < Genes.Count; i++)
            {
                if (Random.value < AlgorithmSettings.MutationRate)
                {
                    Genes[i] = !Genes[i];
                }
            }

            CalculateFitness();
        }

        private void CalculateFitness()
        {
            TotalWeight = CalculateWeight();
            TotalPrice = CalculatePrice();
            var overweight = Mathf.Min(0, TotalWeight - AlgorithmSettings.WeightLimit);
            Fitness = TotalPrice - AlgorithmSettings.WeightPenalty * overweight;
        }

        private float CalculateWeight()
        {
            float totalWeight = 0;
            for (int i = 0; i < Genes.Count; i++)
            {
                if (Genes[i])
                {
                    totalWeight += AlgorithmSettings.Items[i].Weight;
                }
            }

            return totalWeight;
        }

        private float CalculatePrice()
        {
            float totalPrice = 0;
            for (int i = 0; i < Genes.Count; i++)
            {
                if (Genes[i])
                {
                    totalPrice += AlgorithmSettings.Items[i].Price;
                }
            }

            return totalPrice;
        }
    }
}