using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodoAPI.Validation
{
    public class FutureDateTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }
            return false;            
        }
        public override string FormatErrorMessage(string name)
        {
            return $"{name} deve ser uma data no futuro.";
        }
    }
}
