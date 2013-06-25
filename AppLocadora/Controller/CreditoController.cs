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
            try
            {
                IQueryable<Credito> query = _database.AsQueryable<Credito>();
                return (from q in query
                        where q.Formato == formato
                        orderby q.Valor
                        select q);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Credito SelectByFormato(Formato formato, Filme movie)
        {
            try
            {
                return (from c in movie.Copias
                        where c.Credito.Formato == formato
                        select c.Credito).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
