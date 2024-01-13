namespace AI
{
    public static class GeneticAlgorithm
    {
        public static Population CurrentPopulation { get; set; }

        public static void Run()
        {
            if (AlgorithmSettings.Items.Count == 0)
                AlgorithmSettings.GenerateItems();
            CurrentPopulation = Population.Initialize();
            CurrentPopulation.SortByFitness();
            for (int i = 0; i < AlgorithmSettings.NumberOfGenerations; i++)
            {
                CurrentPopulation.Mutate();
                CurrentPopulation.SortByFitness();
            }
        }
    }
}