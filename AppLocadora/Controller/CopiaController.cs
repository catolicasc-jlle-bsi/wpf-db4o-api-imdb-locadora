using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using AppLocadora.Model;
using Db4objects.Db4o;

namespace AppLocadora.Controller
{
    public class CopiaController : BasicOperations
    {
        public Guid GuiAvaliable()
        {
            return Guid.NewGuid();
        }

        public Dictionary<int, Copia> HelpComboBox()
        {
            int qtdeDefault = 5;
            Dictionary<int, Copia> copias = new Dictionary<int, Copia>();

            var formatos = new FormatoController().SelectAll<Formato>().ToList();

            for (int control = 1; control <= qtdeDefault; control++)
                formatos.ForEach(f => copias.Add(control, new Copia { Formato = f, }));

            return copias;
        }
    }
}
