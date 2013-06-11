using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLocadora.Model
{
    public class Usuario : Pessoa
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
