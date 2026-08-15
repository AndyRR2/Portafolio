using Proyect.Models;

namespace Proyect.Repositories{
    public interface IBoardRepository{
        public List<Board> GetAll();
        public List<Board> GetAllByOwnerUser(int? idUser);
        public List<Board> GetAllByAsignedTask(int? idUser);
        public Board GetById(int? idBoard);
        public void Create(Board newBoard);
        public void Update(Board newBoard);
        public void Remove(int? idBoard);
        public void Disable(int? idBoard);
        public bool ChechAsignedTask(int? idUser, int? idBoard);
        public bool BoardExists(string? boardName);
    }
}