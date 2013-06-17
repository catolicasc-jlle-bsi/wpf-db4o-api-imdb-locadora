using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLocadora.Model
{
    public class Credito
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeDias { get; set; }
    }
}
