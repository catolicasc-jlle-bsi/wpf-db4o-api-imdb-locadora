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
            List<Copia> copias = new List<Copia>();
            foreach (var copia in param)
            {
                foreach (var formato in copia.Key)
                {
                    copias.Add(new Copia(copia.Value));
                }
            }

            return copias;
        }

        public IEnumerable<Copia> SelectAllCopiasByMovie(Filme movie)
        {
            IQueryable<Filme> query = _database.AsQueryable<Filme>();
            return (from q in query
                    where q == movie
                    select q.Copias).SingleOrDefault();
        }
    }
}
