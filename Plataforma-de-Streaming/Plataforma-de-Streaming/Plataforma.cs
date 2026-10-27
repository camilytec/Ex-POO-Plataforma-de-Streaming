using System;
using System.Collections.Generic;

namespace Plataforma_de_Streaming
{
    public class Plataforma
    {
        private List<string> catalogo;

        public Plataforma(List<string> catalogo)
        {
            this.catalogo = new List<string>(catalogo);
        }

        public List<string> BuscarConteudo(string termo)
        {
            List<string> encontrados = new List<string>();

            if (termo == null || termo.Trim() == "")
                return encontrados;

            foreach (string titulo in catalogo)
            {
                if (titulo.ToLower().Contains(termo.ToLower()))
                    encontrados.Add(titulo);
            }

            return encontrados;
        }

        public List<string> RecomendarPara(Usuario usuario)
        {
            List<string> recomendacoes = new List<string>();

            if (usuario == null)
                return recomendacoes;

            List<string> historico = usuario.Historico();

            foreach (string titulo in catalogo)
            {
                bool jaAssistiu = false;

                foreach (string registro in historico)
                {
                    if (registro.IndexOf(titulo, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        jaAssistiu = true;
                        break;
                    }
                }

                if (!jaAssistiu)
                    recomendacoes.Add(titulo);

                if (recomendacoes.Count == 3)
                    break;
            }

            return recomendacoes;
        }

        public List<string> Top10()
        {
            List<string> resultado = new List<string>();
            int limite = Math.Min(catalogo.Count, 10); ;

            for (int i = 0; i < limite; i++)
                resultado.Add(catalogo[i]);

            return resultado;
        }
    }
}