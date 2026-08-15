using Proyect.Models;

namespace Proyect.ViewModels{
    public class ListTaskViewModel{
        public int? Id{get;set;}
        public string? Name{get;set;}
        public TaskStat TaskStat{get;set;}
        public string? Description{get;set;}
        public Color Color{get;set;}
        public int? IdBoard{get;set;}
        public string? BoardName{get;set;}
        public int? IdAssignedUser{get;set;}
        public string? AssignedUserName{get;set;}
        public int? IdPropietaryUser{get;set;}
        public string? PropietaryUserName{get;set;}

        public ListTaskViewModel(){}
        public ListTaskViewModel(string? nameBoard, string? nameProp, string? nameAssign, int? id, int? idBoard, string? name, TaskStat status, string? description, Color color, int? idAssignedUser, int? idPropUser){
            Id=id;
            IdBoard=idBoard;
            Name=name;
            TaskStat=status;
            Description=description;
            Color=color;
            IdAssignedUser=idAssignedUser;
            IdPropietaryUser=idPropUser;
            PropietaryUserName=nameProp;
            AssignedUserName=nameAssign;
            BoardName=nameBoard;
        }
        public static List<ListTaskViewModel> FromTask(List<TasK> Tasks)
        {
            List<ListTaskViewModel> ListTaskVM = new List<ListTaskViewModel>();
            
            foreach (var TasK in Tasks)
            {
                ListTaskViewModel newTaskVM = new ListTaskViewModel();
                newTaskVM.Id=TasK.Id;
                newTaskVM.Name=TasK.Name;
                newTaskVM.TaskStat=TasK.TaskStat;
                newTaskVM.Description=TasK.Description;
                newTaskVM.Color=TasK.Color;
                newTaskVM.IdBoard=TasK.OwnBoard.Id;
                newTaskVM.BoardName=TasK.OwnBoard.Name;
                newTaskVM.IdAssignedUser=TasK.Assigned.Id;
                newTaskVM.AssignedUserName=TasK.Assigned.Name;
                newTaskVM.IdPropietaryUser=TasK.Propietary.Id;
                newTaskVM.PropietaryUserName=TasK.Propietary.Name;
                ListTaskVM.Add(newTaskVM);
            }
            return(ListTaskVM);
        }
    }
}