using System;
using System.Collections.Generic;

namespace Streaming
{
    public class Serie
    {
        // Atributos
        public string Titulo { get; private set; }
        public string Genero { get; private set; }

        // Cada posição = uma temporada; o valor = quantidade de episódios dela
        private List<int> episodiosPorTemporada;

        // Episódios assistidos no formato "temporada-episodio" (ex.: "1-2")
        private HashSet<string> assistidos;

        public Serie(string titulo, string genero, List<int> episodiosPorTemporada)
        {
            Titulo = titulo;
            Genero = genero;
            this.episodiosPorTemporada = episodiosPorTemporada;
            assistidos = new HashSet<string>();
        }

        // Método 1: reproduz um episódio, marca como assistido e devolve o texto do histórico
        // (devolve null se o episódio não existir)
        public string ReproduzirEpisodio(int temporada, int episodio)
        {
            if (temporada < 1 || temporada > episodiosPorTemporada.Count
                || episodio < 1 || episodio > episodiosPorTemporada[temporada - 1])
            {
                Console.WriteLine("Episodio inexistente: T" + temporada + "E" + episodio);
                return null;
            }

            Console.WriteLine("Reproduzindo serie: " + Titulo + " - T" + temporada + "E" + episodio);
            MarcarComoAssistido(temporada, episodio);
            return "Serie: " + Titulo + " - T" + temporada + "E" + episodio;
        }

        // Método 2: marca um episódio como assistido
        public void MarcarComoAssistido(int temporada, int episodio)
        {
            if (temporada >= 1 && temporada <= episodiosPorTemporada.Count
                && episodio >= 1 && episodio <= episodiosPorTemporada[temporada - 1])
            {
                assistidos.Add(temporada + "-" + episodio);
            }
        }

        // Método 3: lista os episódios de uma temporada, indicando os assistidos
        public List<string> ListarEpisodios(int temporada)
        {
            List<string> lista = new List<string>();

            if (temporada < 1 || temporada > episodiosPorTemporada.Count)
            {
                return lista;
            }

            for (int ep = 1; ep <= episodiosPorTemporada[temporada - 1]; ep++)
            {
                string marca = assistidos.Contains(temporada + "-" + ep) ? " [assistido]" : "";
                lista.Add("T" + temporada + "E" + ep + marca);
            }

            return lista;
        }
    }
}
