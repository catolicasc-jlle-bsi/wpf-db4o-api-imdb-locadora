using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using AppLocadora.Model;

namespace AppLocadora.Controller
{
    public class FormatoController : BasicOperations
    {
        public Dictionary<int, Formato> HelpComboBox(int qtdeCopias)
        {
            Dictionary<int, Formato> copias = new Dictionary<int, Formato>();

            var formatos = new FormatoController().SelectAll<Formato>().ToList();

            for (int control = 1; control <= qtdeCopias; control++)
                formatos.ForEach(f => copias.Add(control, f));

            return copias;
        }
    }
}
