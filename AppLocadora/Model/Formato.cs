using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLocadora.Model
{
    public class Formato
    {
        //Implementar no Seeds
        public string Descricao { get; set; } //DVD, BluRay
        public Credito Credito { get; set; }
    }
}
