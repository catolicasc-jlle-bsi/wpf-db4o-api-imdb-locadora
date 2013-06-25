using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using AppLocadora.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace AppLocadora.Controller
{
    public class CopiaController : BasicOperations
    {
        public Guid GuiAvaliable()
        {
            return Guid.NewGuid();
        }

        public List<Copia> Generate(Dictionary<List<Model.Formato>, Model.Credito> param)
        {
            try
            {
                List<Copia> copias = new List<Copia>();
                param.ToList().ForEach(p => p.Key.ForEach(k => copias.Add(new Copia(p.Value))));
                return copias;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Copia> SelectAllCopiasByMovie(Filme movie)
        {
            try
            {
                IQueryable<Filme> query = _database.AsQueryable<Filme>();
                return (from q in query
                        where q == movie
                        select q.Copias).SingleOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
