using System;
using System.Collections.Generic;

namespace Plataforma_de_Streaming
{
    public class Serie
    {
        public string Titulo { get; private set; }
        public string Genero { get; private set; }

        private List<int> episodiosPorTemporada;
        private HashSet<string> assistidos;

        public Serie(string titulo, string genero, List<int> episodiosPorTemporada)
        {
            Titulo = titulo;
            Genero = genero;
            this.episodiosPorTemporada = new List<int>(episodiosPorTemporada);
            assistidos = new HashSet<string>();
        }

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

        public void MarcarComoAssistido(int temporada, int episodio)
        {
            if (temporada >= 1 && temporada <= episodiosPorTemporada.Count
                && episodio >= 1 && episodio <= episodiosPorTemporada[temporada - 1])
            {
                assistidos.Add(temporada + "-" + episodio);
            }
        }

        public List<string> ListarEpisodios(int temporada)
        {
            List<string> lista = new List<string>();

            if (temporada < 1 || temporada > episodiosPorTemporada.Count)
                return lista;

            for (int ep = 1; ep <= episodiosPorTemporada[temporada - 1]; ep++)
            {
                string marca = assistidos.Contains(temporada + "-" + ep) ? " [assistido]" : "";
                lista.Add("T" + temporada + "E" + ep + marca);
            }

            return lista;
        }
    }
}