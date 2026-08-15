using Proyect.ViewModels;

namespace Proyect.Models{
    public class UseR{
        public int? Id{get;set;}
        public string? Name{get;set;}
        public string? Password{get;set;}
        public AccessLevel AccessLevel{get;set;}
        public UseR(){}
        public UseR(int? id, string? name, string? password, AccessLevel level){
            Id=id;
            Name=name;
            Password=password;
            AccessLevel=level;
        }
        public UseR(int? id, string? name){
            Id=id;
            Name=name;
        }
        public static UseR FromCreateUser(CreateUserViewModel userVM){
            return new UseR
            {
                Name=userVM.Name,
                Password=userVM.Password,
                AccessLevel=userVM.AccessLevel
            };
        }
        public static UseR FromEditUser(EditUserViewModel userVM){
            return new UseR
            {
                Id=userVM.Id,
                Name=userVM.Name,
                Password=userVM.Password,
                AccessLevel=userVM.AccessLevel
            };
        }
        public static UseR FromDeleteUser(DeleteUserViewModel userVM){
            return new UseR
            {
                Id=userVM.Id,
                Password=userVM.ActualPassword
            };
        }
    }
}