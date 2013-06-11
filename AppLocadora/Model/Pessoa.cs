using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AppLocadora.Model
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime Nascimento { get; set; }
        public Endereco Endereco { get; set; }
    }
}
