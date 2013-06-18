using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Exceptions;
using AppLocadora.Controller;

namespace AppLocadora.Model
{
    public class Locacao
    {
        /*
        public Locacao(Cliente cliente, Filme filme, Formato formato)
        {
            foreach (Copia copia in filme.Copias)
            {
                if (copia.Formato.Equals(formato))
                {
                    bool disponivel = new LocacaoController().CopiaDisponivel(copia);
                    if (disponivel)
                    {
                        this.Copia = copia;
                        break;
                    }
                }
            }

            if (this.Copia == null)
            {
                throw new FilmeAlugadoException("O filme está locado");
            }

            if (cliente.Conta.Saldo < this.Copia.Formato.Credito.Valor)
            {
                throw new SaldoInsuficienteException("Saldo insuficiente");
            }

            this.DataLocacao = DateTime.Now;
        }

        public Locacao(Cliente cliente, Copia copia)
        {

            bool disponivel = new LocacaoController().CopiaDisponivel(copia);
            if (disponivel)
            {
                this.Copia = copia;
            }

            if (this.Copia == null)
            {
                throw new FilmeAlugadoException("O filme está locado");
            }

            if (cliente.Conta.Saldo < this.Copia.Formato.Credito.Valor)
            {
                throw new SaldoInsuficienteException("Saldo insuficiente");
            }

            this.DataLocacao = DateTime.Now;
            this.DataPrevistaDevolucao = CalculaDataDevolucao();
        }*/
        /*
        public DateTime CalculaDataDevolucao()
        {
            DateTime devolucao = this.DataLocacao;
            devolucao.AddDays(this.Copia.Formato.Credito.QuantidadeDias);
            return devolucao;
        }*/

        public Filme Filme { get; set; }
        public Cliente Cliente { get; set; }
        public Copia Copia { get; set; }

        public DateTime DataLocacao { get; private set; }

        /// <remarks>
        /// A data de devolução deve variar de acordo com a data de locação
        /// mais o valor de crédito do filme.
        /// </remarks>
        public DateTime DataPrevistaDevolucao { get; private set; }

        public DateTime DataDevolucao { get; private set; }
    }
}
