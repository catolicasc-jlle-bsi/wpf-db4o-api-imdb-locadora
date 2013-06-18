using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Model;
using Db4objects.Db4o;
using System.IO;
using System.Reflection;

namespace AppLocadora.Helper
{
    public class Seeds : BasicOperations
    {
        public Seeds()
        {
            if (SelectAll<GerenciadorProxy>().Count() == 0)
                StoreProxy();

            if (SelectAll<Configuration>().Count() == 0)
                StoreConfiguration();

            if (SelectAll<Censura>().Count() == 0)
                StoreCensura();

            if (SelectAll<Sexo>().Count() == 0)
                StoreSexo();

            if (SelectAll<Credito>().Count() == 0)
                StoreCredito();
        }

        private void StoreProxy()
        {
            Save(new GerenciadorProxy { Active = false, Endereco = string.Empty, Porta = string.Empty });
        }

        private void StoreConfiguration()
        {
            Save(new Configuration { DefaultPoster = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "no_picture.gif") });
        }

        private void StoreSexo()
        {
            List<Sexo> sexos = new List<Sexo>()
            {
                new Sexo { Descricao = "M" },
                new Sexo { Descricao = "F" },
            };

            sexos.ToList().ForEach(c => Save(c));
        }

        private void StoreCensura()
        {
            List<Censura> censuras = new List<Censura>()
            {
                new Censura { Classificacao = "Livre" },
                new Censura { Classificacao = "10" },
                new Censura { Classificacao = "12" },
                new Censura { Classificacao = "14" },
                new Censura { Classificacao = "16" },
                new Censura { Classificacao = "18" },
            };

            censuras.ToList().ForEach(c => Save(c));
        }

        private void StoreCredito()
        {
            List<Credito> creditosDVD = new List<Credito>()
            {
                new Credito { Valor = 1, Descricao = "DVD 1", QuantidadeDias = 5, Formato = Formato.DVD },
                new Credito { Valor = 2, Descricao = "DVD 2", QuantidadeDias = 4, Formato = Formato.DVD },
                new Credito { Valor = 3, Descricao = "DVD 3", QuantidadeDias = 3, Formato = Formato.DVD },
                new Credito { Valor = 4, Descricao = "DVD 4", QuantidadeDias = 2, Formato = Formato.DVD },
                new Credito { Valor = 5, Descricao = "DVD 5", QuantidadeDias = 1, Formato = Formato.DVD },
            };

            creditosDVD.ForEach(c => Save(c));

            List<Credito> creditosBluray = new List<Credito>()
            {
                new Credito { Valor = 2, Descricao = "Bluray 1", QuantidadeDias = 5, Formato = Formato.Bluray },
                new Credito { Valor = 4, Descricao = "Bluray 2", QuantidadeDias = 4, Formato = Formato.Bluray },
                new Credito { Valor = 6, Descricao = "Bluray 3", QuantidadeDias = 3, Formato = Formato.Bluray },
                new Credito { Valor = 8, Descricao = "Bluray 4", QuantidadeDias = 2, Formato = Formato.Bluray },
                new Credito { Valor = 10, Descricao = "Bluray 5", QuantidadeDias = 1, Formato = Formato.Bluray },
            };

            creditosBluray.ForEach(c => Save(c));
        }

        #region Sem conexão com a Internet
        private void StoreGenero()
        {
            List<Genero> generos = new List<Genero>()
            {
                new Genero { Descricao = "Ação" },
                new Genero { Descricao = "Animação" },
                new Genero { Descricao = "Aventura" },
                new Genero { Descricao = "Chanchada" },
                new Genero { Descricao = "Cinema catástrofe" },
                new Genero { Descricao = "Comédia" },
                new Genero { Descricao = "Comédia romântica" },
                new Genero { Descricao = "Comédia dramática" },
                new Genero { Descricao = "Comédia de ação" },
                new Genero { Descricao = "Cult" },
                new Genero { Descricao = "Documentários" },
                new Genero { Descricao = "Drama" },
                new Genero { Descricao = "Espionagem" },
                new Genero { Descricao = "Erótico" },
                new Genero { Descricao = "Fantasia" },
                new Genero { Descricao = "Faroeste" },
                new Genero { Descricao = "Ficção científica" },
                new Genero { Descricao = "Franchise/Séries" },
                new Genero { Descricao = "Guerra" },
                new Genero { Descricao = "Machinima" },
                new Genero { Descricao = "Musical" },
                new Genero { Descricao = "Filme noir" },
                new Genero { Descricao = "Policial" },
                new Genero { Descricao = "Pornochanchada" },
                new Genero { Descricao = "Pornográfico" },
                new Genero { Descricao = "Romance" },
                new Genero { Descricao = "Suspense" },
                new Genero { Descricao = "Terror" },
                new Genero { Descricao = "Trash" },
            };

            generos.ToList().ForEach(c => new BasicOperations().Save(c));
        }

        private void StoreDiretor()
        {
            List<Diretor> diretores = new List<Diretor>()
            {
                new Diretor { Nome = "Martin Scorsese", },
                new Diretor { Nome = "Steven Spielberg", },
                new Diretor { Nome = "Alfred Hitchcock", },
                new Diretor { Nome = "Francis Ford Coppola", },
                new Diretor { Nome = "Stanley Kubrick", },
                new Diretor { Nome = "Quentin Tarantino", },
                new Diretor { Nome = "Christopher Nolan", },
                new Diretor { Nome = "Clint Eastwood", },
                new Diretor { Nome = "James Cameron", },
                new Diretor { Nome = "Peter Jackson", },
            };

            diretores.ToList().ForEach(c => new BasicOperations().Save(c));
        }

        private void StoreAtor()
        {
            List<Ator> atores = new List<Ator>()
            {
                new Ator { Nome = "Nicolas Cage", },
                new Ator { Nome = "Brad Pitt", },
                new Ator { Nome = "Julia Roberts", },
                new Ator { Nome = "Will Smith", },
                new Ator { Nome = "Jim Carrey", },
                new Ator { Nome = "Adam Sandler", },
                new Ator { Nome = "Tom Cruise", },
                new Ator { Nome = "Denzel Washington", },
                new Ator { Nome = "Angelina Jolie", },
                new Ator { Nome = "Al Pacino", },
                new Ator { Nome = "Tom Hanks", },
                new Ator { Nome = "Robin Williams", },
                new Ator { Nome = "Johnny Depp", },
                new Ator { Nome = "Leonardo DiCaprio", },
                new Ator { Nome = "Bruce Willis", },
                new Ator { Nome = "Robert De Niro", },
                new Ator { Nome = "Morgan Freeman", },
                new Ator { Nome = "John Travolta", },
                new Ator { Nome = "Sandra Bullock", },
                new Ator { Nome = "Arnold Schwarzenegger", },
                new Ator { Nome = "Jet Li", },
                new Ator { Nome = "Clint Eastwood", },
                new Ator { Nome = "Mel Gibson", },
                new Ator { Nome = "Richard Gere", },
                new Ator { Nome = "John Wayne", },
                new Ator { Nome = "Sylvester Stallone", },
                new Ator { Nome = "Kevin Costner", },
                new Ator { Nome = "Meryl Streep", },
                new Ator { Nome = "Cameron Diaz", },
                new Ator { Nome = "Harrison Ford", },
            };

            atores.ToList().ForEach(c => new BasicOperations().Save(c));
        }
        #endregion

        #region Não usado
        private void StoreUsuario()
        {
            Usuario usuario = new Usuario
            {
                Login = "admin",
                Password = "admin",
            };

            Save(usuario);
        }
        #endregion
    }
}
