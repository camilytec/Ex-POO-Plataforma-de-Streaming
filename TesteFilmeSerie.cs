using System;
using System.Collections.Generic;

namespace Streaming
{
    // Teste da Pessoa 1 (Filme e Serie). Nao tem Main, para nao conflitar com o Program.cs do grupo.
    // Para rodar: no Program.cs, chame  TesteFilmeSerie.Executar();
    // Quando o Usuario estiver pronto, troque "historico.Add(x)" por  usuario.RegistrarNoHistorico(x)
    public static class TesteFilmeSerie
    {
        public static void Executar()
        {
            // Simula o historico do usuario
            List<string> historico = new List<string>();

            // Reproducao de um filme
            Filme filme = new Filme("Interestelar", "Ficcao cientifica", 169);
            Console.WriteLine("Duracao: " + filme.GetDuracao() + " min");
            historico.Add(filme.Reproduzir());
            filme.Pausar();

            Console.WriteLine();

            // Reproducao de um episodio
            Serie serie = new Serie("Dark", "Suspense", new List<int> { 10, 8, 8 });
            string registro = serie.ReproduzirEpisodio(1, 2);
            if (registro != null)
            {
                historico.Add(registro);
            }
            serie.MarcarComoAssistido(1, 3);

            Console.WriteLine();
            Console.WriteLine("Episodios da temporada 1:");
            foreach (string ep in serie.ListarEpisodios(1))
            {
                Console.WriteLine("  " + ep);
            }

            // Historico registrado
            Console.WriteLine();
            Console.WriteLine("Historico:");
            foreach (string item in historico)
            {
                Console.WriteLine("  - " + item);
            }
        }
    }
}
