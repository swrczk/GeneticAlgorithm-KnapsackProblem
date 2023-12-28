using System.Collections.Generic;

namespace AI
{
    public class Population
    {
        public List<CandidateSolution> Solutions { get; set; } = new List<CandidateSolution>();

        public void Mutate()
        {
            Solutions.ForEach(solution => solution.Mutate());
        }

        public void SortByFitness()
        {
            Solutions.Sort((a, b) => b.Fitness.CompareTo(a.Fitness));
        }

        public Population CreateNextGeneration()
        {
            Population nextGeneration = new Population();
            for (int i = 0; i < Solutions.Count; i++)
            {
                CandidateSolution solution = new CandidateSolution();
                solution.Genes = Solutions[i].Genes;
                nextGeneration.Solutions.Add(solution);
            }

            nextGeneration.Mutate();
            nextGeneration.SortByFitness();
            return nextGeneration;
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