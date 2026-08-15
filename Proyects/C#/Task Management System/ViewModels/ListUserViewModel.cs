using Proyect.Models;

namespace Proyect.ViewModels{
    public class ListUserViewModel{
        public int? Id{get;set;}
        public string? Name{get;set;}
        public AccessLevel AccessLevel{get;set;}
        public ListUserViewModel(){}
        public ListUserViewModel(int? id, string? name, AccessLevel level){
            Id=id;
            Name=name;
            AccessLevel=level;
        }
        public static List<ListUserViewModel> FromUser(List<UseR> users)
        {
            List<ListUserViewModel> listUsersVM = new List<ListUserViewModel>();
            
            foreach (var user in users)
            {
                ListUserViewModel userVM = new ListUserViewModel();
                userVM.Id = user.Id;
                userVM.Name = user.Name;
                userVM.AccessLevel=user.AccessLevel;
                listUsersVM.Add(userVM);
            }
            return(listUsersVM);
        }
    }
}