using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLocadora.Helper;
using AppLocadora.View;
using System.Collections.ObjectModel;

namespace AppLocadora.Controller
{
    public class ApplicationController
    {
        public ApplicationController()
        { 
            new Seeds();
        }
    }
}
