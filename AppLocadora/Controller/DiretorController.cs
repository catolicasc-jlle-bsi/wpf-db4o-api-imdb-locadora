using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using AppLocadora.Model;
using Db4objects.Db4o.Linq;

namespace AppLocadora.Controller
{
    public class DiretorController : BasicOperations
    {
        public List<Diretor> Cast(List<string> parameter)
        {
            List<Diretor> temp = new List<Diretor>();
            if (parameter == null) { return temp; };

            parameter.ForEach(p => temp.Add(this.Valid(new Diretor() { Nome = p, })));
            return temp;
        }

        private Diretor Valid(Diretor parameter)
        {
            IQueryable<Diretor> query = _database.AsQueryable<Diretor>();

            var d = (from q in query
                     where q.Nome == parameter.Nome
                     select q).FirstOrDefault();

            return (d != null) ? d : parameter;
        }
    }
}
