using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace AppLocadora.Helper
{
    public class CampoObrigatorio : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString().Trim() == string.Empty)
            {
                return new ValidationResult(false, "Campo obrigatório.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
