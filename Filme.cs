using System;

namespace Streaming
{
    public class Filme
    {
        // Atributos
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

        // Método 1: inicia a reprodução e devolve o texto que vai para o histórico
        public string Reproduzir()
        {
            EstaTocando = true;
            Console.WriteLine("Reproduzindo filme: " + Titulo);
            return "Filme: " + Titulo;
        }

        // Método 2: pausa a reprodução
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

        // Método 3: duração em minutos
        public int GetDuracao()
        {
            return DuracaoMinutos;
        }
    }
}
