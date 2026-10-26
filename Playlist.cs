using System;
using System.Collections.Generic;

public class Class1
{
    public class Playlist
    {
     
        private string nome;
        private List<string> midias;

      
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

        public Playlist(string nome)
        {
            this.nome = nome;
            midias = new List<string>();
        }

        public void AdicionarMidia(string midia)
        {
            if (midia!= null && midia != "" && !midias.Contains(midia))
            {
                midias.Add(midia);
            }
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
