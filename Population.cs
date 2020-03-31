namespace problema_mochila_AG
{
    public class Population
    {
        int popSize = 10;
        Item[] individuals = new Item[6];
        int fittest = 0;

        //Initialize population
        public void initializePopulation(int size)
        {
            //TODO
        }

        //Get the fittest individual
        public Item getFittest()
        {
            int maxFit = int.MinValue;
            int maxFitIndex = 0;
            for (int i = 0; i < individuals.Length; i++)
            {
                if (maxFit <= individuals[i].fitness)
                {
                    maxFit = individuals[i].fitness;
                    maxFitIndex = i;
                }
            }
            fittest = individuals[maxFitIndex].fitness;
            return individuals[maxFitIndex];
        }

        //Get the second most fittest individual
        public Item getSecondFittest()
        {
            int maxFit1 = 0;
            int maxFit2 = 0;
            for (int i = 0; i < individuals.length; i++)
            {
                if (individuals[i].fitness > individuals[maxFit1].fitness)
                {
                    maxFit2 = maxFit1;
                    maxFit1 = i;
                }
                else if (individuals[i].fitness > individuals[maxFit2].fitness)
                {
                    maxFit2 = i;
                }
            }
            return individuals[maxFit2];
        }

        //Get index of least fittest individual
        public int getLeastFittestIndex()
        {
            int minFitVal = Integer.MAX_VALUE;
            int minFitIndex = 0;
            for (int i = 0; i < individuals.length; i++)
            {
                if (minFitVal >= individuals[i].fitness)
                {
                    minFitVal = individuals[i].fitness;
                    minFitIndex = i;
                }
            }
            return minFitIndex;
        }

        //Calculate fitness of each individual
        public void calculateFitness()
        {

            for (int i = 0; i < individuals.length; i++)
            {
                individuals[i].calcFitness();
            }
            getFittest();
        }
    }
}