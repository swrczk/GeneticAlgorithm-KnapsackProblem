using System.Collections.Generic;

namespace AI
{
    public class Population
    {
        public List<CandidateSolution> Solutions { get; private set; } = new List<CandidateSolution>();

        public void Mutate()
        {
            Solutions.ForEach(solution => solution.Mutate());
        }

        public void SortByFitness()
        {
            Solutions.Sort((a, b) => b.Fitness.CompareTo(a.Fitness));
        }

        public static Population Initialize()
        {
            var population = new Population();
            population.Solutions = new List<CandidateSolution>(AlgorithmSettings.PopulationSize);
            for (int i = 0; i < AlgorithmSettings.PopulationSize; i++)
            {
                population.Solutions.Add(CandidateSolution.Initialize());
            }

            return population;
        }
    }
}