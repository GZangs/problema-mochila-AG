using System;

namespace problema_mochila_AG
{
    public class Individuo
    {
        public int fitness = 0;
        public Item[] items { get; set; }

        public Individuo(Item[] items)
        {
            this.items = items;
        }

        public int getFitness() {
            int fitness = 0;
            
            foreach (var item in items) {
                fitness += item.Pontos;
            }

            return fitness;
        }

        internal int getTotalWeight()
        {
            int weight = 0;
            
            foreach (var item in items) {
                weight += item.Peso;
            }

            return weight;
        }
    }
}
