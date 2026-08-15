using System.ComponentModel.DataAnnotations;

using Proyect.Models;

namespace Proyect.ViewModels{
    public class EditBoardViewModel{
        public int? Id{get;set;}//It does not need attributes since it is hidden in the View

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
        public EditBoardViewModel(){
            Users = new List<UseR>();//Ensures that you always have a valid list instance
        }
        public EditBoardViewModel(int? id, int? idUser, string? name, string? description, BoardStatus status, List<UseR> userList){
            Id=id;
            IdPropietaryUser=idUser;
            Name=name;
            Description=description;
            BoardStatus=status;
            Users=userList;
        }
        public static EditBoardViewModel FromBoard(Board board)
        {
            return new EditBoardViewModel
            {
                Id = board.Id,
                IdPropietaryUser = board.Propietary.Id,
                Name = board.Name,
                Description=board.Description,
                BoardStatus = (Proyect.Models.BoardStatus)board.BoardStatus
            };
        }
    }
}