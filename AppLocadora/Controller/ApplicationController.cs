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

        public List<T> SelectedObjects<T>(ObservableCollection<SelectableObject<T>> param)
        {
            return (from c in param
                    where c.IsSelected
                    select c.ObjectData).ToList<T>();
        }
    }
}
