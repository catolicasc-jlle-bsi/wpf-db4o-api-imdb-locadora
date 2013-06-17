using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLocadora.Model
{
    public class Cliente : Pessoa
    {
        public Conta Conta { get; set; }
    }
}
