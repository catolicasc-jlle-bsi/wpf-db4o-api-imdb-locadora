using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using AppLocadora.Model;
using Db4objects.Db4o.Linq;

namespace AppLocadora.Controller
{
    public class RoteiristaController : BasicOperations
    {
        public List<Roteirista> Cast(List<string> parameter)
        {
            try
            {
                List<Roteirista> temp = new List<Roteirista>();
                if (parameter == null) { return temp; };

                parameter.ForEach(p => temp.Add(this.Valid(new Roteirista() { Nome = p, })));
                return temp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Roteirista Valid(Roteirista parameter)
        {
            try
            {
                IQueryable<Roteirista> query = _database.AsQueryable<Roteirista>();
                var d = (from q in query
                         where q.Nome == parameter.Nome
                         select q).FirstOrDefault();

                return (d != null) ? d : parameter;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
