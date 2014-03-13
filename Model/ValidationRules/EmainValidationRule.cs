using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MVVM_Example.Model.ValidationRules
{
    public class EmainValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            String pattern = "@";
            Regex regex = new Regex(pattern);

            String userInput = (String)value;
            if (regex.IsMatch(userInput))
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "Email is invalid");
            }
        }
    }
}
