using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using AppLocadora.Model;
using Db4objects.Db4o.Linq;

namespace AppLocadora.Controller
{
    public class FilmeController : BasicOperations
    {
        public Filme Cast(Imdb imdb)
        {
            try
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
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
        public IEnumerable<Filme> SelectAll()
        {
            try
            {
                IQueryable<Filme> query = _database.AsQueryable<Filme>();
                return (from q in query
                        select new Filme
                            {
                                Nome = q.Nome,
                                Sinopse = q.Sinopse,
                                AnoLancamento = q.AnoLancamento,
                            }).AsEnumerable<Filme>();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        */

        public Filme Single(Filme filme)
        {
            try
            {
                IQueryable<Filme> query = _database.AsQueryable<Filme>();
                return (from q in query
                        where q == filme
                        select q).SingleOrDefault();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
        public void Delete(Filme filme)
        {
            try
            {
                IQueryable<Filme> query = _database.AsQueryable<Filme>();
                _database.Delete((from q in query
                                  where q == filme
                                  select q).SingleOrDefault());
            }
            catch (Exception e)
            {
                throw e;
            }
        }*/

        public IEnumerable<Filme> SearchAllMoviesByName(string param)
        {
            try
            {
                IQueryable<Filme> query = _database.AsQueryable<Filme>();
                return (from q in query
                        where q.Nome.Contains(param)
                        orderby q.Nome
                        select q);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private byte[] Cast(string url)
        {
            try
            {
                return Session.Current.Internet.DownBytes(url);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
