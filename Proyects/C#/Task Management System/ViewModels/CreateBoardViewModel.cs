using System.ComponentModel.DataAnnotations;

using Proyect.Models;

namespace Proyect.ViewModels{
    public class CreateBoardViewModel{

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "UseR Propietary")]
        public int? IdPropietaryUser{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Name Board")]
        [MaxLength(20)]
        public string? Name{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Description")]
        [MaxLength(30)]
        public string? Description{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Status")]
        public BoardStatus BoardStatus{get;set;}

        public List<UseR> Users{get;set;}//Required to save the list of selectable Users obtained from the DB
        public CreateBoardViewModel(){
            Users = new List<UseR>();//Ensures that you always have a valid list instance
        }
        public CreateBoardViewModel(int? idUser, string? name, string? nameUser, string? description, BoardStatus status, List<UseR> userList){
            IdPropietaryUser=idUser;
            Name=name;
            Description=description;
            BoardStatus=status;
            Users=userList;
        }
    }
}