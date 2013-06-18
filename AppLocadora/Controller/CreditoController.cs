using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using AppLocadora.Model;
using Db4objects.Db4o.Linq;

namespace AppLocadora.Controller
{
    public class CreditoController : BasicOperations
    {
        public IEnumerable<Credito> SelectAllByFormato(Formato formato)
        {
            IQueryable<Credito> query = _database.AsQueryable<Credito>();
            return (from q in query
                    where q.Formato == formato
                    orderby q.Valor
                    select q);
        }

        public Credito SelectByFormato(Formato formato, Filme movie)
        {
            var copias = (from c in movie.Copias
                          where c.Credito.Formato == formato
                          select c.Credito);

             //movie.Copias.Where(w => w.Credito.Formato == formato).Select(s => s.Credito).SingleOrDefault();
            return copias.FirstOrDefault();
            /*
            IQueryable<Filme> query = _database.AsQueryable<Filme>();
            var copias = (from q in query
                          where q == movie && q.Copias.Where(w => w.Credito.Formato 
                          select q.Copias);
            copias.Where*/
        }
    }
}
