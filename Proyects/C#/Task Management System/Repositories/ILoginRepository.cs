using Proyect.Models;

namespace Proyect.Repositories{
    public interface ILoginRepository{
        public bool AutenticateUser(string userName, string password);
        public UseR TakeUser(string userName, string password);
    }
}