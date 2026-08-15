using System.ComponentModel.DataAnnotations;

using Proyect.Models;

namespace Proyect.ViewModels{
    public class EditUserViewModel{
        public int? Id{get;set;}//It does not need attributes since it is hidden in the View

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Name")]
        [MaxLength(20)]
        public string? Name{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z]).+$", ErrorMessage = "The password must contain at least one capital letter.")]
        [MinLength(8)]
        [Display(Name = "Actual Password")]
        public string? ActualPassword{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z]).+$", ErrorMessage = "The password must contain at least one capital letter.")]
        [MinLength(8)]
        [Display(Name = "Nueva Password")]
        public string? Password{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Access Level")]
        public AccessLevel AccessLevel{get;set;}

        public EditUserViewModel(){}
        public EditUserViewModel(int? id, string? name, string? password, string? actualPassword, AccessLevel level){
            Id=id;
            Name=name;
            Password=password;
            ActualPassword=actualPassword;
            AccessLevel=level;
        }
        public static EditUserViewModel FromUser(UseR user){
            return new EditUserViewModel
            {
                Id=user.Id,
                Name=user.Name,
                Password=user.Password,
                AccessLevel=user.AccessLevel
            };
        }
    }
}