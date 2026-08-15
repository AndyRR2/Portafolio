using System.ComponentModel.DataAnnotations;

using Proyect.Models;

namespace Proyect.ViewModels{
    public class AssignTaskViewModel{
        public int? Id{get;set;}//It does not need attributes since it is hidden in the View

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Id UseR Assigned")]
        public int? IdAssignedUser{get;set;}
        
        public List<int?> IdUsers{get;set;}//Required to save the list of selectable Ids obtained from the DB
        public AssignTaskViewModel(){
            IdUsers = new List<int?>();//Ensures that you always have a valid list instance
        }
        public AssignTaskViewModel(int? id, int? idAssignedUser, List<int?> idUsers){
            Id=id;
            IdAssignedUser=idAssignedUser;
            IdUsers=idUsers;
        }
        public static AssignTaskViewModel FromTask(TasK newTask)
        {
            AssignTaskViewModel newTaskVM = new AssignTaskViewModel();
            newTaskVM.Id = newTask.Id;
            newTaskVM.IdAssignedUser = newTask.Assigned.Id;
            return(newTaskVM);
        }
    }
}