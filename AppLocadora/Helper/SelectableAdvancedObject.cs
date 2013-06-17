using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLocadora.Helper
{
    public class SelectableAdvancedObject<T1, T2>
    {
        public bool IsSelected { get; set; }
        public T1 ObjectQtde { get; set; }
        public T2 ObjectData { get; set; }

        public SelectableAdvancedObject(T1 objectQtde, T2 objectData)
        {
            ObjectQtde = objectQtde;
            ObjectData = objectData;
        }

        public SelectableAdvancedObject(T1 objectQtde, T2 objectData, bool isSelected)
        {
            IsSelected = isSelected;
            ObjectQtde = objectQtde;
            ObjectData = objectData;
        }
    }
}
