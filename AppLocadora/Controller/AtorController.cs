using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using AppLocadora.Model;

namespace AppLocadora.Controller
{
    public class AtorController : BasicOperations
    {
        public List<Ator> Cast(List<string> parameter)
        {
            List<Ator> temp = new List<Ator>();
            if (parameter == null) { return temp; };

            parameter.ForEach(p => temp.Add(this.Valid(new Ator() { Nome = p, })));
            return temp;
        }

        private Ator Valid(Ator parameter)
        {
            IQueryable<Ator> query = _database.AsQueryable<Ator>();

            var d = (from q in query
                     where q.Nome == parameter.Nome
                     select q).FirstOrDefault();

            return (d != null) ? d : parameter;
        }
    }
}
