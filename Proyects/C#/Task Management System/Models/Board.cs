using Proyect.ViewModels;

namespace Proyect.Models{
    public enum BoardStatus{
        Active=1,
        Unnactive=2
    }
    public class Board{
        public int? Id{get;set;}
        public string? Name{get;set;}
        public string? Description{get;set;}
        public BoardStatus BoardStatus{get;set;}
        public UseR Propietary{get;set;}

        public Board(){
            Propietary = new UseR();
        }
        public Board(int? id, string? name){
            Id=id;
            Name=name;
        }
        
        public Board(int? id, string? name, string? description, BoardStatus status, int? idUser, string? nameUser){
            Id=id;
            Name=name;
            Description=description;
            BoardStatus=status;
            Propietary = new UseR(idUser, nameUser);
        }
        public static Board FromCreateBoardViewModel(CreateBoardViewModel boardVM)
        {
            return new Board
            {
                Propietary = new UseR(boardVM.IdPropietaryUser,null),
                Name = boardVM.Name,
                Description=boardVM.Description,
                BoardStatus = (Proyect.Models.BoardStatus)boardVM.BoardStatus
            };
        }
        public static Board FromEditBoardViewModel(EditBoardViewModel boardVM)
        {
            return new Board
            {
                Id = boardVM.Id,
                Propietary = new UseR(boardVM.IdPropietaryUser,null),
                Name = boardVM.Name,
                Description=boardVM.Description,
                BoardStatus = (Proyect.Models.BoardStatus)boardVM.BoardStatus
            };
        }
    }
}
