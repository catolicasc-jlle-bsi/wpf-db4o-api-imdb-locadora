using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLocadora.Model
{
    public class Copia
    {
        public Guid ID { get; set; }
        public Credito Credito { get; set; }

        public Copia(Credito credito)
        {
            this.ID = Guid.NewGuid();
            this.Credito = credito;
        }
    }
}
