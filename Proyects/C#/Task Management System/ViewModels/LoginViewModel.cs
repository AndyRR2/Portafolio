using System.ComponentModel.DataAnnotations;
namespace Proyect.ViewModels{
    public class LoginViewModel{

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Name")]
        [MaxLength(20)]
        public string? Name{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password{get;set;}

        public LoginViewModel(){}
        public LoginViewModel(string? name, string? password){
            Name=name;
            Password=password;
        }
    }
}