using Proyect.ViewModels;

namespace Proyect.Models{
    public enum AccessLevel{
        admin=1,
        simple=2
    }
    public class Login{
        public string? Name{get;set;}
        public string? Password{get;set;}
        public AccessLevel AccessLevel{get;set;}
        public Login(){}
        public Login(string? name, string? password, AccessLevel level){
            Name=name;
            Password=password;
            AccessLevel=level;
        }
        public static Login FromLoginViewModel(LoginViewModel loginVM){
            return new Login
            {
                Name=loginVM.Name,
                Password=loginVM.Password
            };
        }
    }
}
