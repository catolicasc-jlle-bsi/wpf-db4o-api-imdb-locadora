using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLocadora.Model
{
    public class Filme
    {
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public int AnoLancamento { get; set; }
        public string Duracao { get; set; }

        /// <remarks>
        /// Na documentação parece que um filme pode ser classificado em
        /// vários gêneros. Verificar!
        /// </remarks>
        public List<Genero> Generos { get; set; }
        public Censura Censura { get; set; }

        public List<Diretor> Diretores { get; set; }
        public List<Roteirista> Roteiristas { get; set; }
        public List<Ator> Atores { get; set; }

        public List<Copia> Copias { get; set; }

        public byte[] Capa { get; set; }
        public byte[] Trailer { get; set; }

        /*
        public static explicit operator Filme(Imdb imdb)
        {
            
            if (imdb == null) { new Filme(); };

            // Ignorado os outros tempos
            string duracao = string.Empty;
            if (imdb.Runtime != null)
                duracao = imdb.Runtime.FirstOrDefault();

            List<Genero> generos = new List<Genero>();
            if (imdb.Genres != null)
                imdb.Genres.ForEach(g => generos.Add(new Genero() { Descricao = g, }));

            List<Diretor> diretores = new List<Diretor>();
            if (imdb.Directors != null)
                imdb.Directors.ForEach(d => diretores.Add(new Diretor() { Nome = d, }));

            List<Roteirista> roteiristas = new List<Roteirista>();
            if (imdb.Writers != null)
                imdb.Writers.ForEach(w => roteiristas.Add(new Roteirista() { Nome = w, }));

            List<Ator> atores = new List<Ator>();
            if (imdb.Actors != null)
                imdb.Actors.ForEach(a => atores.Add(new Ator() { Nome = a, }));

            return
                new Filme
                {
                    Nome = imdb.Title,
                    Sinopse = imdb.PlotSimple,
                    AnoLancamento = imdb.Year,
                    Duracao = duracao,
                    Generos = generos,
                    Diretores = diretores,
                    Roteiristas = roteiristas,
                    Atores = atores,
                };
        }*/
    }
}
