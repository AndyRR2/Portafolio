using System.ComponentModel.DataAnnotations;

using Proyect.Models;

namespace Proyect.ViewModels{
    public class CreateUserViewModel{

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Name")]
        [MaxLength(20)]
        public string? Name{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z]).+$", ErrorMessage = "The password must contain at least one capital letter.")]
        [MinLength(8)]
        [Display(Name = "Password")]
        public string? Password{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Access Level")]
        public AccessLevel AccessLevel{get;set;}

        public CreateUserViewModel(){}
        public CreateUserViewModel(string? name, string? password, AccessLevel level){
            Name=name;
            Password=password;
            AccessLevel=level;
        }
    }
}