using Proyect.Models;

namespace Proyect.ViewModels{
    public class ListBoardViewModel{
        public int? Id{get;set;}
        public string? Name{get;set;}
        public string? Description{get;set;}
        public BoardStatus BoardStatus{get;set;}
        public int? IdPropietaryUser{get;set;}
        public string? PropietaryUserName{get;set;}
        public ListBoardViewModel(){}
        public ListBoardViewModel(int? id, string? name, string? description, BoardStatus status, int? idUser, string? nameUser){
            Id=id;
            Name=name;
            Description=description;
            BoardStatus=status;
            IdPropietaryUser=idUser;
            PropietaryUserName=nameUser;
        }
        public static List<ListBoardViewModel> FromBoard(List<Board> boards)
        {
            List<ListBoardViewModel> ListBoardVM = new List<ListBoardViewModel>();
            
            foreach (var board in boards)
            {
                ListBoardViewModel newBoardVM = new ListBoardViewModel();
                newBoardVM.Id = board.Id;
                newBoardVM.Name = board.Name;
                newBoardVM.Description = board.Description;
                newBoardVM.BoardStatus = (Proyect.Models.BoardStatus)board.BoardStatus;
                newBoardVM.IdPropietaryUser = board.Propietary.Id;
                newBoardVM.PropietaryUserName = board.Propietary.Name;
                ListBoardVM.Add(newBoardVM);
            }
            return(ListBoardVM);
        }
    }
}