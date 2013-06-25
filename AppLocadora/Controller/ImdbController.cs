using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using Db4objects.Db4o;
using AppLocadora.Model;
using Db4objects.Db4o.Linq;
using Newtonsoft.Json;

namespace AppLocadora.Controller
{
    public class ImdbController : BasicOperations
    {
        #region Padrão de URL

        private static string _address_by_movie_title = @"http://imdbapi.org/?title={0}&type=json&plot=simple&episode=0&limit=10&yg=0&mt=M&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0";
        private static string _address_by_movie_id = @"http://imdbapi.org/?id=tt{0}&type=json&plot=simple&episode=1&lang=en-US&aka=simple&release=simple&business=0&tech=0";

        #endregion

        /// <summary>
        ///  Tratativa para evitar gravar um objeto IMDB sem o título, 
        ///  pois é um campo que identifica a mídia
        /// </summary>
        /// <param name="imdb"></param>
        public void Save(Imdb imdb)
        {
            try
            {
                if (String.IsNullOrEmpty(imdb.Title)) { return; }

                if (Exists(imdb.ImdbId)) { return; }

                _database.Store(imdb);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool Exists(string identifier)
        {
            try
            {
                IQueryable<Imdb> query = _database.AsQueryable<Imdb>();
                return (from q in query
                        where q.ImdbId == identifier
                        select q.ImdbId).Any();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Imdb Valid(Imdb parameter)
        {
            try
            {
                IQueryable<Imdb> query = _database.AsQueryable<Imdb>();

                var d = (from q in query
                         where q.ImdbId == parameter.ImdbId
                         select q).FirstOrDefault();

                return (d != null) ? d : parameter;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string LastId()
        {
            try
            {
                IQueryable<Imdb> query = _database.AsQueryable<Imdb>();
                return query.FirstOrDefault() != null ?
                    (from q in query
                     orderby q.ImdbId descending
                     select q.ImdbId).FirstOrDefault() : "0";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void IntegrateWithDatabase()
        {
            try
            {
                IQueryable<Imdb> query = _database.AsQueryable<Imdb>();
                List<Imdb> movies = (from q in query
                                     where q.Type == "M"
                                     select q).ToList();

                movies.ForEach(movie => Save(new FilmeController().Cast(movie)));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
        public void IntegrateWithDatabase(Imdb parameter)
        {
            IQueryable<Imdb> query = _database.AsQueryable<Imdb>();
            var imdb = Valid(parameter);

            movies.ForEach(movie => Save(new FilmeController().Cast(movie)));
        }
        */
        public Imdb SearchByMovieName(string param)
        {
            Imdb imdb;
            string json = null;

            try
            {
                json = Session.Current.Internet.Down(string.Format(_address_by_movie_title, param));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro desconhecido. Detalhes: {0}", ex.Message));
            }

            if (json.Contains("Film not found")) { throw new Exception("Nenhum filme encontrado com o nome procurado!"); };

            try
            {
                imdb = JsonConvert.DeserializeObject<List<Imdb>>(json).First();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro desconhecido. Detalhes: {0}", ex.Message));
            }

            return this.Valid(imdb);
        }

        public List<Imdb> SearchAllByMovieName(string param)
        {
            List<Imdb> imdb;
            string json = null;

            try
            {
                json = Session.Current.Internet.Down(string.Format(_address_by_movie_title, param));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro desconhecido. Detalhes: {0}", ex.Message));
            }

            if (json.Contains("Film not found")) { throw new Exception("Nenhum filme encontrado com o nome procurado!"); };

            try
            {
                imdb = JsonConvert.DeserializeObject<List<Imdb>>(json);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro desconhecido. Detalhes: {0}", ex.Message));
            }

            List<Imdb> validImdb = new List<Imdb>();
            imdb.ForEach(i => validImdb.Add(this.Valid(i)));
            return validImdb;
        }
    }
}
