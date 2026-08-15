using Proyect.Models;

namespace Proyect.Repositories{
    public interface ITaskRepository{
        public List<TasK> GetAll();
        public TasK GetById(int? idTask);
        public void Create(TasK newTask);
        public void Update(TasK newTask);
        public void Remove(int? idTask);
        public void Assign(int? idTask, int? idUser);
        public void ChangeStatus(TasK TasK);
        public void DisableByDeletedBoard(int? idTask);
        public void DisableByDeletedUser(int? idUser);
        public List<TasK> GetAllByOwnerBoard(int? idBoard);
        public List<TasK> GetAllByOwnerUser(int? idUser);
        public bool TaskExists(string? TaskName);
    }
}