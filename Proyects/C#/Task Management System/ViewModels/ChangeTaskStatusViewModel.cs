using System.ComponentModel.DataAnnotations;

using Proyect.Models;

namespace Proyect.ViewModels{
    public class ChangeTaskStatViewModel{
        public int? Id{get;set;}//It does not need attributes since it is hidden in the View

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Status")]
        public TaskStat TaskStat{get;set;}
        
        public ChangeTaskStatViewModel(){}
        public ChangeTaskStatViewModel(int? id, TaskStat status){
            Id=id;
            TaskStat = status;
        }
        public static ChangeTaskStatViewModel FromTask(TasK newTask)
        {
            ChangeTaskStatViewModel newTaskVM = new ChangeTaskStatViewModel();
            newTaskVM.Id = newTask.Id;
            newTaskVM.TaskStat = newTask.TaskStat;
            return(newTaskVM);
        }
    }
}