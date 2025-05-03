using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Task1.VeiwModels
{
    public class RegisterUserViewModel
    {
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string Adderss { get; set; }
    }
}
