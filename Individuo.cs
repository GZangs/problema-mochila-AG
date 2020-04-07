using System;

namespace problema_mochila_AG
{
    public class Individuo
    {
        public Item[] items { get; set; }

        public Individuo(Item[] items)
        {
            this.items = items;
        }

        public int getFitness()
        {
            int fitness = 0;

            foreach (var item in items)
            {
                if (item != null)
                {
                    fitness += item.Pontos;
                }
            }

            return fitness;
        }

        internal int getTotalWeight()
        {
            int weight = 0;

            foreach (var item in items)
            {
                if (item != null)
                {
                    weight += item.Peso;
                }
            }

            return weight;
        }
    }
}
