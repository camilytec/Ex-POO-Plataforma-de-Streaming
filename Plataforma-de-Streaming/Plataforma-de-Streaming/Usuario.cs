using System;
using System.Collections.Generic;

namespace Plataforma_de_Streaming
{
    public class Usuario
    {
        public string Nome { get; private set; }
        private List<Playlist> playlists;
        private List<string> favoritos;
        private List<string> historico;

        public Usuario(string nome)
        {
            Nome = nome;
            playlists = new List<Playlist>();
            favoritos = new List<string>();
            historico = new List<string>();
        }

        public Playlist CriarPlaylist(string nome)
        {
            Playlist playlist = new Playlist(nome);
            playlists.Add(playlist);
            return playlist;
        }

        public void Favoritar(string midia)
        {
            if (!string.IsNullOrWhiteSpace(midia) && !favoritos.Contains(midia))
                favoritos.Add(midia);
        }

        public List<string> Historico()
        {
            return new List<string>(historico);
        }

        public void RegistrarReproducao(string midia)
        {
            if (!string.IsNullOrWhiteSpace(midia))
                historico.Add(midia);
        }
    }
}