using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLocadora.Exceptions
{
    public class FilmeAlugadoException : Exception
    {
        public FilmeAlugadoException() { }

        public FilmeAlugadoException(string mensagem) : base(mensagem) { }

    }
}
