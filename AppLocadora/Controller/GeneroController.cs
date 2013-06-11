using AppLocadora.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Model;
using Db4objects.Db4o.Linq;

namespace AppLocadora.Controller
{
    public class GeneroController : BasicOperations
    {
        public List<Genero> Cast(List<string> parameter)
        {
            List<Genero> temp = new List<Genero>();
            if (parameter == null) { return temp; };

            parameter.ForEach(p => temp.Add(this.Valid(new Genero() { Descricao = p, })));
            return temp;
        }

        private Genero Valid(Genero parameter)
        {
            IQueryable<Genero> query = _database.AsQueryable<Genero>();

            var d = (from q in query
                     where q.Descricao == parameter.Descricao
                     select q).FirstOrDefault();

            return (d != null) ? d : parameter;
        }
    }
}
