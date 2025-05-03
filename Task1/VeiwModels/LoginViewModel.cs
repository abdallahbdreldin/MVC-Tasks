using System.ComponentModel.DataAnnotations;

namespace Task1.VeiwModels
{
    public class LoginViewModel
    {
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
