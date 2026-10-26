using System;

public class Class1
using System.Collections.Generic;

{
    public class Usuario {

    private List<Playlist> playlists;
    private List<string> favoritos;
    private List<string> historico;
    private string nome;


    public string Nome
    {
        get
        {
            return nome;
        }
        private set
        {
            nome = value;
        }
    }

    public Usuario(string nome)
    {
        this.nome = nome;
        this.playlists = new List<Playlist>();
        this.favoritos = new List<string>();
        this.historico = new List<string>();
    }

    public Playlist CriarPlaylist(string nome)
    {
        Playlist playlist = new Playlist(nome);
        playlists.Add(playlist);

        return playlist;
    }


    public void Favoritar(string midia)
    {
        if (midia != null && midia != "" && !favoritos.Contains(midia))
        {
            favoritos.Add(midia);
        }
    }


    public List<string> Historico()
    {
        return new List<string>(historico);
    }

    public void RegistrarReproducao(string midia)
    {
        if (midia != null && midia != "")
        {
            historico.Add(midia);
        }
    }
  }
}