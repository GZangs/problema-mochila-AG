using System;
using System.Linq;

namespace problema_mochila_AG
{
    public class Program
    {
        public static int pesoMochila = 30;

        public static Item sacoDormir = new Item("Saco de dormir", 15, 15);
        public static Item corda = new Item("Corda", 3, 7);
        public static Item canivete = new Item("Canivete", 2, 10);
        public static Item tocha = new Item("Tocha", 5, 5);
        public static Item garrafa = new Item("Garrafa", 9, 8);
        public static Item comida = new Item("Comida", 20, 17);
        public static Item[] itemsIdx = new Item[] { sacoDormir, corda, canivete, tocha, garrafa, comida };

        public static Individuo[] populacao = null;
        public static Individuo[] populacaoDescendentes = null;
        public static Individuo fittest = null;
        public static Individuo secondFittest = null;
        static void Main(string[] args)
        {
            /*
            populacao inicial
            A1 -> {1,0,0,1,1,0} 
            A2 -> {0,0,1,1,1,0}
            A3 -> {0,1,0,1,0,0}
            A4 -> {0,1,1,0,0,1}
            */

            var individuo1 = new Individuo(new Item[] { sacoDormir, null, null, tocha, garrafa, null });
            var individuo2 = new Individuo(new Item[] { null, null, canivete, tocha, garrafa, null });
            var individuo3 = new Individuo(new Item[] { null, corda, null, tocha, null, null });
            var individuo4 = new Individuo(new Item[] { null, corda, canivete, null, null, comida });
            populacao = new Individuo[] { individuo1, individuo2, individuo3, individuo4 };
            populacaoDescendentes = new Individuo[] { };

            while (true)
            {
                selecao();
                populacaoDescendentes.Append(crossover());
                mutation();
            }
        }

        public static void selecao()
        {
            fittest = populacao
                .OrderByDescending(i => i.getFitness())
                .Where(i => i.getTotalWeight() <= pesoMochila)
                .FirstOrDefault();

            secondFittest = populacao
                .OrderByDescending(i => i.getFitness())
                .Where(i => i.getTotalWeight() <= pesoMochila)
                .ToArray()[1];
        }

        public static Individuo crossover()
        {
            Random rn = new Random();

            int crossoverIdx = rn.Next(populacao[0].items.Length);
            var items = fittest.items.Take(crossoverIdx).Concat(secondFittest.items.Skip(crossoverIdx)).ToArray();
            return new Individuo(items);
        }

        public static void mutation()
        {
            Random rn = new Random();

            //Select a random mutation point
            int mutationIdx = rn.Next(populacao[0].items.Length);
            var mutationRate = 0.05;

            if (rn.Next(0, 1) <= mutationRate)
            {
                if (fittest.items[mutationIdx] != null)
                {
                    fittest.items[mutationIdx] = null;
                }
                else
                {
                    fittest.items[mutationIdx] = itemsIdx[mutationIdx];
                }
            }
        }
    }
}
