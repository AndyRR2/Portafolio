using System.ComponentModel.DataAnnotations;

using Proyect.Models;

namespace Proyect.ViewModels{
    public class CreateTaskViewModel{
        
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Own Board")]
        public int? IdBoard{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Name")]
        [MaxLength(20)]
        public string? Name{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Status")]
        public TaskStat TaskStat{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Description")]
        [MaxLength(30)]
        public string? Description{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Color")]
        public Color Color{get;set;}

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "UseR Propietary")]
        public int? IdPropietaryUser{get;set;}

        public List<Board> Boards{get;set;}//Required to save the list to selectables obtained from the DB
        public List<UseR> Users{get;set;}//Required to save the list to selectables obtained from the DB
        public CreateTaskViewModel(){
            Boards = new List<Board>();//Ensures that you always have a valid list instance
            Users = new List<UseR>();//Ensures that you always have a valid list instance
        }
        public CreateTaskViewModel(int? idBoard, string? name, TaskStat status, string? description, Color color, int? idPropUser, List<Board> boards, List<UseR> users){
            Name=name;
            TaskStat=status;
            Description=description;
            Color=color;
            IdBoard=idBoard;
            IdPropietaryUser=idPropUser;
            Boards=boards;
            Users=users;
        }
        
    }
}