using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLocadora.Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException() { }

        public SaldoInsuficienteException(string mensagem) : base(mensagem) { }

    }
}
