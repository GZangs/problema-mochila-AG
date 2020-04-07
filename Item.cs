using System;

namespace problema_mochila_AG
{
    public class Item
    {
        public string Name {get;set;}
        public int Peso {get;set;}
        public int Pontos {get;set;}

        public Item(string name, int peso, int pontos)
        {
            Name = name;
            Peso = peso;
            Pontos = pontos;
        }
    }
}
