using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using Db4objects.Db4o;
using AppLocadora.Model;
using Db4objects.Db4o.Linq;

namespace AppLocadora.Controller
{
    public class LocacaoController : BasicOperations
    {
        public bool CopiaDisponivel(Copia copia)
        {
            IQueryable<Locacao> query = _database.AsQueryable<Locacao>();

            bool exists = (from q in query
                           where q.Copia == copia
                           select q).SingleOrDefault() != null;

            if (!exists) { return true; }

            return (from q in query
                    where q.Copia == copia && q.DataDevolucao == null
                    select q).SingleOrDefault() == null;

        }

        /*
        public Dictionary<Model.Filme, List<Model.Copia>> Search(string param)
        {
            var allMovies = new FilmeController().SearchAllMoviesByName(param);
            if (allMovies == null) throw new Exception("Nenhum filme encontrado!");

            Dictionary<Model.Filme, List<Model.Copia>> dicMovies = new Dictionary<Model.Filme, List<Model.Copia>>();
            allMovies.ToList().ForEach(f => dicMovies.Add(f, new CopiaController().SelectAllCopiasByMovie(f).ToList()));
            return dicMovies;
        }*/

    }
}
