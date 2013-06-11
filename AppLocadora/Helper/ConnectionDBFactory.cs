using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;

namespace AppLocadora.Helper
{
    public class ConnectionDBFactory
    {
        /*
        public static readonly string PATH = 
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "locadora.yap");
        */

        public static readonly string PATH =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "locadora.yap");

        public IEmbeddedObjectContainer Create()
        {
            return Db4oEmbedded.OpenFile(PATH);
        }
    }
}
