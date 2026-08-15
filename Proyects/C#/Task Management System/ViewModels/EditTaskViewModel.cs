using System.ComponentModel.DataAnnotations;

using Proyect.Models;

namespace Proyect.ViewModels{
    public class EditTaskViewModel{
        public int? Id{get;set;}//It does not need attributes since it is hidden in the View

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Id Board")]
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
        [Display(Name = "Id UseR Propietary")]
        public int? IdPropietaryUser{get;set;}
        public List<Board> Boards{get;set;}//Required to save the list to selectables obtained from the DB
        public List<UseR> Users{get;set;}//Required to save the list to selectables obtained from the DB
        public EditTaskViewModel(){
            Boards = new List<Board>();//Ensures that you always have a valid list instance
            Users = new List<UseR>();//Ensures that you always have a valid list instance
        }
        public EditTaskViewModel(int? id, int? idBoard, string? name, TaskStat status, string? description, Color color, int? idPropUser, List<Board> boards, List<UseR> users){
            Id=id;
            Name=name;
            TaskStat=status;
            Description=description;
            Color=color;
            IdBoard=idBoard;
            IdPropietaryUser=idPropUser;
            Boards=boards;
            Users=users;
        }
        public static EditTaskViewModel FromTask(TasK newTask)
        {
            EditTaskViewModel newTaskVM = new EditTaskViewModel();
            newTaskVM.Id = newTask.Id;
            newTaskVM.Name = newTask.Name;
            newTaskVM.TaskStat = (Proyect.Models.TaskStat)newTask.TaskStat;
            newTaskVM.Description = newTask.Description;
            newTaskVM.Color = newTask.Color;
            newTaskVM.IdPropietaryUser = newTask.Propietary.Id;
            newTaskVM.IdBoard = newTask.OwnBoard.Id;
            return(newTaskVM);
        } 
    }
}