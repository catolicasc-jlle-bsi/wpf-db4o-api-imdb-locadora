using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using AppLocadora.Model;
using Db4objects.Db4o.Linq;

namespace AppLocadora.Controller
{
    public class ClienteController : BasicOperations
    {
        public IEnumerable<Cliente> SearchAllClientsByName(string param)
        {
            IQueryable<Cliente> query = _database.AsQueryable<Cliente>();
            return (from q in query
                    where q.Nome.Contains(param)
                    orderby q.Nome
                    select q);
        }
    }
}
