using Microsoft.AspNetCore.Mvc;

using Proyect.Repositories;
using Proyect.Models;
using Proyect.ViewModels;

namespace Proyect.Controllers{
    public class UserController: Controller{
        private readonly IUserRepository repoUser;
        private readonly ILoginRepository repoLogin;
        private readonly ILogger<HomeController> _logger;
        public UserController(ILogger<HomeController> logger, IUserRepository userRepo, ILoginRepository logRepo) 
        {
            _logger = logger;
            repoUser = userRepo;
            repoLogin = logRepo;
        }

        public IActionResult Index(){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                List<UseR> listUsers = repoUser.GetAll();
                List<ListUserViewModel> listUsersVM = ListUserViewModel.FromUser(listUsers);

                return View(listUsersVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method Index from the controller UseR: {ex.ToString()}");
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult AddUser(){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                } 
                if(!isAdmin()){
                    _logger.LogWarning("You must be an administrator to perform the action");
                    return NotFound();
                } 

                CreateUserViewModel newUserVM = new CreateUserViewModel();

                return View(newUserVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method AddUser from the controller UseR: {ex.ToString()}");
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult AddUserFromForm(CreateUserViewModel newUserVM){
            try
            {
                if(!ModelState.IsValid) return RedirectToAction("Index","Login");
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                } 
                if(!isAdmin()){
                    _logger.LogWarning("You must be an administrator to perform the action");
                    return NotFound();
                } 

                UseR newUser = UseR.FromCreateUser(newUserVM);
                repoUser.Create(newUser);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method AddUserFromForm from the controller UseR: {ex.ToString()}");
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult EditUser(int? idUser){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                } 

                if(!idUser.HasValue) return NotFound();//Verify that it has a Value assigned
                UseR userToEdit = repoUser.GetById(idUser);
                EditUserViewModel userToEditVM = new EditUserViewModel();
                
                if (isAdmin()){//If it is Admin it can edit
                    userToEditVM = EditUserViewModel.FromUser(userToEdit);//convert from Model to ViewModel
                }
                else{
                    UseR loggedInUser = repoLogin.TakeUser(HttpContext.Session.GetString("Name"),HttpContext.Session.GetString("Password"));
                    if (loggedInUser.Id == idUser){
                        userToEditVM = EditUserViewModel.FromUser(userToEdit);//I convert from Model to ViewModel
                    }else{
                        _logger.LogWarning("You must be an administrator to perform the action");
                        return NotFound();
                    }
                }

                return View(userToEditVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method EditUser from the controller UseR: {ex.ToString()}");
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult EditUserFromForm(EditUserViewModel userToEditVM){
            try
            { 
                if(!ModelState.IsValid) return RedirectToAction("Index","Login");
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                //Check if the Current password entered matches that of the same user in the DB
                if(userToEditVM.ActualPassword == repoUser.GetById(userToEditVM.Id).Password){
                    UseR userToEdit = UseR.FromEditUser(userToEditVM);//convert from ViewModel to Model
                    repoUser.Update(userToEdit);
                    return RedirectToAction("Index");
                }else{
                    _logger.LogInformation($"The password entered is incorrect");
                    return RedirectToAction("EditUser", new { idUser = userToEditVM.Id });//Return to EditUser with the same user ID that you wanted to edit
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method EditUserFromForm from the controller UseR: {ex.ToString()}");
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult DeleteUser(int? idUser){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                if(!idUser.HasValue) return NotFound();
                UseR userToDelete = repoUser.GetById(idUser);
                DeleteUserViewModel userToDeleteVM = new DeleteUserViewModel();

                if (isAdmin()){//If it is Admin it can Borrarlo
                    userToDeleteVM = DeleteUserViewModel.FromUser(userToDelete);
                }else{
                    UseR loggedInUser = repoLogin.TakeUser(HttpContext.Session.GetString("Name"),HttpContext.Session.GetString("Password"));
                    if (loggedInUser.Id == idUser){
                        userToDeleteVM = DeleteUserViewModel.FromUser(userToDelete);
                    }else{
                        _logger.LogWarning("You must be an administrator to perform the action");
                        return NotFound();
                    }
                }
                return View(userToDeleteVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method DeleteUser from the controller UseR: {ex.ToString()}");
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult DeleteFromForm(DeleteUserViewModel userToDeleteVM){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                if(userToDeleteVM.ActualPassword == repoUser.GetById(userToDeleteVM.Id).Password){
                    UseR userToDelete = UseR.FromDeleteUser(userToDeleteVM);//convert from ViewModel to Model
                    repoUser.Remove(userToDelete.Id);
                    return RedirectToAction("Index");
                }else{
                    _logger.LogInformation($"The password entered is incorrect");
                    return RedirectToAction("DeleteUser", new { idUser = userToDeleteVM.Id });//Return to DeleteUser with the same user ID that you wanted to delete
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method EliminarUsuarioFromForm from the controller UseR: {ex.ToString()}");
                return BadRequest();
            }
        }
        private bool isAdmin()
        {
            if (HttpContext.Session != null && HttpContext.Session.GetString("AccessLevel") == "admin"){
                return true;
            }else{
                return false;
            }
        }
        private bool isLogin()
        {
            if (HttpContext.Session != null && HttpContext.Session.GetString("AccessLevel") == "admin" || HttpContext.Session.GetString("AccessLevel") == "simple"){
                return true;
            }else{
                _logger.LogWarning("You must be logged in to enter the page");
                return false;
            }
        }
    }
}