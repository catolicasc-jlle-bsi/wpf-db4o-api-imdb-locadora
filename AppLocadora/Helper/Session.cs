using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using AppLocadora.Helper;
using System.Net;

namespace AppLocadora.Model
{
    public sealed class Session
    {
        private static readonly Session instance;
        public IObjectContainer Database { get; set; }
        public ConnectionInternetFactory Internet { get; set; }
        //public Usuario Usuario { get; set; }
        //public Locacao Locacao { get; set; }

        public static Session Current
        {
            get
            {
                return instance;
            }
        }

        static Session()
        {
            instance = new Session();
            instance.Database = new ConnectionDBFactory().Create();
            instance.Internet = new ConnectionInternetFactory().Create();
            //instancia.Usuario = new Usuario();
            //instancia.Locacao = new Locacao();
        }

        private Session() { }
    }
}
