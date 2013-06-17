using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AppLocadora.Helper
{
    public class ObservableCollectionHelper
    {
        public ObservableCollection<T> Convert<T>(IEnumerable<T> original)
        {
            return new ObservableCollection<T>(original);
        }

        public static List<T> SelectedObjects<T>(ObservableCollection<SelectableObject<T>> param)
        {
            return (from c in param
                    where c.IsSelected
                    select c.ObjectData).ToList<T>();
        }
    }
}
