using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLocadora.Model
{
    public class Filme
    {
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public int AnoLancamento { get; set; }
        public string Duracao { get; set; }

        public List<Genero> Generos { get; set; }
        public Censura Censura { get; set; }

        public List<Diretor> Diretores { get; set; }
        public List<Roteirista> Roteiristas { get; set; }
        public List<Ator> Atores { get; set; }

        public List<Copia> Copias { get; set; }

        public byte[] Capa { get; set; }
        public byte[] Trailer { get; set; }
    }
}
