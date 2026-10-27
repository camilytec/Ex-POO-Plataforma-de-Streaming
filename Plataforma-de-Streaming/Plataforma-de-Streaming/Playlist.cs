using System;
using System.Collections.Generic;

namespace Plataforma_de_Streaming
{
    public class Playlist
    {
        public string Nome { get; private set; }
        private List<string> midias;

        public Playlist(string nome)
        {
            Nome = nome;
            midias = new List<string>();
        }

        public void AdicionarMidia(string midia)
        {
            if (!string.IsNullOrWhiteSpace(midia) && !midias.Contains(midia))
                midias.Add(midia);
        }

        public void RemoverMidia(string midia)
        {
            midias.Remove(midia);
        }

        public List<string> ListarMidias()
        {
            return new List<string>(midias);
        }
    }
}