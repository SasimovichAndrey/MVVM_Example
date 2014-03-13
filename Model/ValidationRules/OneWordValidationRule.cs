using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace MVVM_Example.Model.ValidationRules
{
    public class OneWordValidationRule : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            String pattern = @"^\S*$";
            Regex regex = new Regex(pattern);

            String word = (String)value;
            if(regex.IsMatch(word))
                return ValidationResult.ValidResult;
            else
                return new ValidationResult(false, "Spaces are restricted");
        }
    }
}
