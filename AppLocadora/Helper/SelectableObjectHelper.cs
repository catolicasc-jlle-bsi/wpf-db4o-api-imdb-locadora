using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using AppLocadora.Model;

namespace AppLocadora.Helper
{
    public class SelectableObjectHelper
    {
        public ObservableCollection<SelectableObject<T>> Cast<T>(IEnumerable<T> param, bool isSelected = false)
        {
            List<SelectableObject<T>> so = new List<SelectableObject<T>>();
            param.ToList().ForEach(p => so.Add(new SelectableObject<T>(p, isSelected)));

            return new ObservableCollectionHelper().Convert<SelectableObject<T>>(so);
        }
    }
}
