using System;

namespace Plataforma_de_Streaming
{
    public class Filme
    {
        public string Titulo { get; private set; }
        public string Genero { get; private set; }
        public int DuracaoMinutos { get; private set; }
        public bool EstaTocando { get; private set; }

        public Filme(string titulo, string genero, int duracaoMinutos)
        {
            Titulo = titulo;
            Genero = genero;
            DuracaoMinutos = duracaoMinutos;
            EstaTocando = false;
        }

        public string Reproduzir()
        {
            EstaTocando = true;
            Console.WriteLine("Reproduzindo filme: " + Titulo);
            return "Filme: " + Titulo;
        }

        public void Pausar()
        {
            if (EstaTocando)
            {
                EstaTocando = false;
                Console.WriteLine("Filme pausado: " + Titulo);
            }
            else
            {
                Console.WriteLine("O filme '" + Titulo + "' nao esta sendo reproduzido.");
            }
        }

        public int GetDuracao()
        {
            return DuracaoMinutos;
        }
    }
}