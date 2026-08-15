using System.ComponentModel.DataAnnotations;

using Proyect.Models;

namespace Proyect.ViewModels{
    public class DeleteUserViewModel{
        public int? Id{get;set;}//It does not need attributes since it is hidden in the View

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password from UseR to Delete")]
        public string? ActualPassword{get;set;}

        public DeleteUserViewModel(){}
        public DeleteUserViewModel(int? id, string? actualPassword){
            Id=id;
            ActualPassword=actualPassword;
        }
        public static DeleteUserViewModel FromUser(UseR user){
            return new DeleteUserViewModel
            {
                Id=user.Id,
                ActualPassword=user.Password,
            };
        }
    }
}