using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using AppLocadora.Model;

namespace AppLocadora.Controller
{
    public class FilmeController : BasicOperations
    {
        public Filme Cast(Imdb imdb)
        {
            if (imdb == null) { throw new Exception("Objeto IMDB está nulo!"); };

            return
                new Filme
                {
                    Nome = imdb.Title,
                    Sinopse = imdb.PlotSimple,
                    AnoLancamento = imdb.Year,
                    Duracao = imdb.Runtime != null ? imdb.Runtime.FirstOrDefault() : string.Empty,
                    Generos = new GeneroController().Cast(imdb.Genres),
                    Diretores = new DiretorController().Cast(imdb.Directors),
                    Roteiristas = new RoteiristaController().Cast(imdb.Writers),
                    Atores = new AtorController().Cast(imdb.Actors),
                    Capa = Cast(imdb.Poster), 
                };
        }

        private byte[] Cast(string url)
        {
            return Session.Current.Internet.DownBytes(url);
        }
    }
}
