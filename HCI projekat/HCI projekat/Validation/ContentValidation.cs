using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_projekat.Validation
{
    public class ContentValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var temp = value as string;
                if (string.IsNullOrWhiteSpace(temp))
                {
                    return new ValidationResult(false, "Id se ne sme sastojati samo od razmaka");
                }
                if (temp.Any(ch => char.IsPunctuation(ch)))
                {
                    return new ValidationResult(false, "Id mora biti ljudski čitljiv i ne sme sadržati znakove interpunkcije");
                }
                else
                {
                    return new ValidationResult(true, "");
                }
            }
            catch
            {
                return new ValidationResult(false, "Desila se neočekivana greška");
            }
        }
    }
}
