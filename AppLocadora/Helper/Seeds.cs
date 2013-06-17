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
    public class Seeds
    {
        public Seeds()
        {
            if (File.Exists(ConnectionDBFactory.PATH))
            {
                return;
            }

            StoreProxy();
            StoreConfiguration();

            /*
            StoreUsuario();
            StoreGenero();
            StoreDiretor();
            StoreAtor();*/
            StoreCensura();
            StoreSexo();
            
            
            //StoreFormato();
        }

        private void StoreProxy()
        {
            new BasicOperations().Save(new GerenciadorProxy { Active = false, Endereco = string.Empty, Porta = string.Empty });
        }

        private void StoreConfiguration()
        {
            new BasicOperations().Save(new Configuration { DefaultPoster = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "no_picture.gif")});
        }

        private void StoreSexo()
        {
            List<Sexo> sexos = new List<Sexo>()
            {
                new Sexo { Descricao = "M" },
                new Sexo { Descricao = "F" },
            };

            sexos.ToList().ForEach(c => new BasicOperations().Save(c));
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

            censuras.ToList().ForEach(c => new BasicOperations().Save(c));
        }

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

        #region Não usado

        private void StoreUsuario()
        {
            Usuario usuario = new Usuario
            {
                Login = "admin",
                Password = "admin",
            };

            new BasicOperations().Save(usuario);
        }

        private void StoreFormato()
        {
            List<Formato> formato = new List<Formato>()
            {
                new Formato
                {
                    Descricao = "DVD",
                    Credito = new Credito { Valor = 1, Descricao = "1", QuantidadeDias = 5 },
                },
                new Formato
                {
                    Descricao = "DVD",
                    Credito = new Credito { Valor = 2, Descricao = "2", QuantidadeDias = 4 },
                },
                new Formato
                {
                    Descricao = "DVD",
                    Credito = new Credito { Valor = 3, Descricao = "3", QuantidadeDias = 3 },
                },
                new Formato
                {
                    Descricao = "DVD",
                    Credito = new Credito { Valor = 4, Descricao = "4", QuantidadeDias = 2 },
                },
                new Formato
                {
                    Descricao = "DVD",
                    Credito = new Credito { Valor = 5, Descricao = "5", QuantidadeDias = 1 },
                },
                new Formato
                {
                    Descricao = "Blu-ray",
                    Credito = new Credito { Valor = 2, Descricao = "1", QuantidadeDias = 5 },
                },
                new Formato
                {
                    Descricao = "Blu-ray",
                    Credito = new Credito { Valor = 4, Descricao = "2", QuantidadeDias = 4 },
                },
                new Formato
                {
                    Descricao = "Blu-ray",
                    Credito = new Credito { Valor = 8, Descricao = "3", QuantidadeDias = 3 },
                },
                new Formato
                {
                    Descricao = "Blu-ray",
                    Credito = new Credito { Valor = 10, Descricao = "4", QuantidadeDias = 2 },
                },
                new Formato
                {
                    Descricao = "Blu-ray",
                    Credito = new Credito { Valor = 12, Descricao = "5", QuantidadeDias = 1 },
                },
            };

            new BasicOperations().Save(formato);
        }

        #endregion
    }
}
