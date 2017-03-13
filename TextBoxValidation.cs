using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace prototype2
{
    public class TextBoxValidation : ValidationRule
    {
        public override ValidationResult Validate
          (object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Value cannot be empty.");
            else
            {
                if (value.ToString().Length ==0)
                    return new ValidationResult(false, "*Cannot be empty!");
            }
            return ValidationResult.ValidResult;
        }
    }
}
