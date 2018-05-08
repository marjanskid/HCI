using HCI_projekat.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_projekat.Validation
{
    public class ResouceTypeIdValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var text = value as string;

                foreach (ResourceType rt in Database.getInstance().ResourceTypes)
                {
                    if (rt.Id.Equals(text))
                    {
                        return new ValidationResult(false, "Id mora biti jedinstven");
                    }
                }

                return new ValidationResult(true, "");
            }
            catch
            {
                return new ValidationResult(false, "Desila se neočekivana greška.");
            }
        }
    }
}
