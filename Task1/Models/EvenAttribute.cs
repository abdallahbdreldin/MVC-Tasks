using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class EvenAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int val = int.Parse(value.ToString());

            return (val % 2 ==0);
        }
    }
}
