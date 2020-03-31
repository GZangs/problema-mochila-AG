using System;

namespace problema_mochila_AG
{
    public class Item
    {
        int fitness = 0;
        private string Name {get;set;}
        private int Peso {get;set;}
        private int Pontos {get;set;}

        public Item(string name, int peso, int pontos)
        {
            Name = name;
            Peso = peso;
            Pontos = pontos;
            fitness = 0;
        }
    }
}