using UnityEngine;

namespace GeneticAlgorithm
{
    public class GeneticAlgorithm : Singleton<GeneticAlgorithm>
    {
        public Population CurrentPopulation { get; set; }

        public void Run()
        {
            AlgorithmSettings.GenerateItems();
            CurrentPopulation = Population.Initialize();
            CurrentPopulation.SortByFitness();
            for (int i = 0; i < AlgorithmSettings.NumberOfGenerations; i++)
            {
                CurrentPopulation.Mutate();
                CurrentPopulation.SortByFitness();
            }

            Debug.Log("Best solution found: " + CurrentPopulation.Solutions[0].Fitness);
        }
    }
}