using Proyect.Models;

namespace Proyect.Repositories{
    public interface IUserRepository{
        public List<UseR> GetAll();
        public UseR GetById(int? idUser);
        public void Create(UseR newUser);
        public void Update(UseR newUser);
        public void Remove(int? idUser);
        public bool UserExists(string? userName);
    }
}