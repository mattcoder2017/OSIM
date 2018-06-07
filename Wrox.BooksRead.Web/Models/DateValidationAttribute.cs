using System;
using System.ComponentModel.DataAnnotations;


namespace Wrox.BooksRead.Web.Models
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime result;
            bool isValid = DateTime.TryParse(value.ToString(), out result);
            if (isValid)
                return true;

            return false;
        }
    }
}