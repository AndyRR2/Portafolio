using Proyect.ViewModels;

namespace Proyect.Models{
    public enum TaskStat{
        Ideas=1, 
        ToDo=2, 
        Doing=3, 
        Review=4, 
        Done=5,
        Unnactive=6
    }
    public enum Color{
        Azul=1,
        Rojo=2,
        Amarillo=3,
        Verde=4,
        Rosa=5,
        Morado=6
    }
    public class TasK{
        public int? Id{get;set;}
        public string? Name{get;set;}
        public TaskStat TaskStat{get;set;}
        public string? Description{get;set;}
        public Color Color{get;set;}
        public UseR Propietary{get;set;}
        public UseR Assigned{get;set;}
        public Board OwnBoard{get;set;}
        public TasK(){
            Propietary = new UseR();
            Assigned = new UseR();
            OwnBoard = new Board();
        }
        public TasK(int? id, int? idBoard, string? nameProp, string? nameAssigned, string nameBoard,string? name, TaskStat status, string? description, Color color, int? idAssignedUser, int? idPropUser){
            Id=id;
            Name=name;
            TaskStat=status;
            Description=description;
            Color=color;
            Propietary = new UseR(idPropUser, nameProp);
            Assigned = new UseR(idAssignedUser, nameAssigned);
            OwnBoard = new Board(idBoard, nameBoard);
        }
        public static TasK FromCrearTareaViewModel(CreateTaskViewModel taskVM)//UseR assigned is 0, then assigned in AssignUse
        {
            return new TasK
            {
                Propietary = new UseR(taskVM.IdPropietaryUser,null),
                Assigned = new UseR(null,null),
                OwnBoard = new Board(taskVM.IdBoard,null),
                Name = taskVM.Name,
                Description = taskVM.Description,
                Color = (Proyect.Models.Color)taskVM.Color,
                TaskStat = (Proyect.Models.TaskStat)taskVM.TaskStat,
            };
        }
        public static TasK FromEditTaskViewModel(EditTaskViewModel taskVM)//It is only created with editable properties
        {
            return new TasK
            {
                Propietary = new UseR(taskVM.IdPropietaryUser,null),
                Assigned = new UseR(null,null),
                OwnBoard = new Board(taskVM.IdBoard,null),
                Id = taskVM.Id,
                Name = taskVM.Name,
                Description = taskVM.Description,
                Color = (Proyect.Models.Color)taskVM.Color,
                TaskStat = (Proyect.Models.TaskStat)taskVM.TaskStat,
                
            };
        }
        public static TasK FromAsignarTareaViewModel(AssignTaskViewModel taskVM)//It is only created with the necessary properties
        {
            return new TasK
            {
                Id = taskVM.Id,
                Assigned = new UseR(taskVM.IdAssignedUser,null)
            };
        }
        public static TasK FromChangeTaskStatViewModel(ChangeTaskStatViewModel taskVM)//It is only created with the necessary properties
        {
            return new TasK
            {
                Id = taskVM.Id,
                TaskStat = taskVM.TaskStat
            };
        }
    }
}