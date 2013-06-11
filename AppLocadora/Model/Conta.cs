using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLocadora.Model
{
    public class Conta
    {
        public int Saldo { get; private set; }

        public void AdicionarCredito(int credito)
        {
            this.Saldo += credito;
        }
    }
}
