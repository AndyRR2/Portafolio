using Microsoft.AspNetCore.Mvc;

using Proyect.Repositories;
using Proyect.Models;
using Proyect.ViewModels;

namespace Proyect.Controllers{
    public class TaskController: Controller{
        private readonly ITaskRepository repoTask;
        private readonly IUserRepository repoUser;
        private readonly IBoardRepository repoBoard;
        private readonly ILoginRepository repoLogin;
        private readonly ILogger<HomeController> _logger;
        public TaskController(ILogger<HomeController> logger, ITaskRepository TaskRepo, IUserRepository userRepo, IBoardRepository boardRepo, ILoginRepository logRepo) 
        {
            _logger = logger;
            repoTask = TaskRepo;
            repoUser = userRepo;
            repoBoard = boardRepo;
            repoLogin = logRepo;
        }

        public IActionResult Index(int? idBoard){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                } 

                List<TasK> Tasks = new List<TasK>();

                if(isAdmin()){//If it is Admin it can ver todas las Tasks
                    if (idBoard.HasValue){
                        Tasks = repoTask.GetAllByOwnerBoard(idBoard);
                    }else{
                        Tasks = repoTask.GetAll();
                    }
                }else{
                    UseR loggedInUser = repoLogin.TakeUser(HttpContext.Session.GetString("Name"),HttpContext.Session.GetString("Password"));
                    if ((repoBoard.GetById(idBoard).Propietary.Id == loggedInUser.Id) || repoBoard.ChechAsignedTask(idBoard,loggedInUser.Id)){
                        Tasks = repoTask.GetAllByOwnerBoard(idBoard);   
                    }else{
                        _logger.LogWarning("You must be an administrator to perform the action");
                        return NotFound();
                    }
                }

                List<ListTaskViewModel> listTasksVM = ListTaskViewModel.FromTask(Tasks);
                return View(listTasksVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method Index from the controller TasK: {ex.ToString()}");
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult AddTask(){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                CreateTaskViewModel newTaskVM = new CreateTaskViewModel();

                newTaskVM.Users = repoUser.GetAll();
                newTaskVM.Boards = repoBoard.GetAll();
                
                if((newTaskVM.Boards).Count == 0){//If there are no boards you cannot create Tasks
                    TempData["Message"] = "There are no boards where you can add the TasK.";
                    return RedirectToAction("Index", "UseR");
                }
                return View(newTaskVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method AddTask from the controller TasK: {ex.ToString()}");
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult AddTaskFromForm(CreateTaskViewModel newTaskVM){
            try
            {
                if(!ModelState.IsValid) return RedirectToAction("Index","Login");
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }
                UseR loggedInUser = repoLogin.TakeUser(HttpContext.Session.GetString("Name"),HttpContext.Session.GetString("Password"));
                if (!isAdmin())
                {
                    if (newTaskVM.IdPropietaryUser!=loggedInUser.Id)
                    {
                        _logger.LogWarning("You must be an administrator or owner of the board to perform the action");
                        return NotFound();
                    }
                }
                

                TasK newTask = TasK.FromCrearTareaViewModel(newTaskVM);
                repoTask.Create(newTask);
                return RedirectToAction("Index", "UseR");//Redirect to index with Board id
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method AddTaskFromForm from the controller TasK: {ex.ToString()}");
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult EditTask(int? idTask){  
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }
                if(!idTask.HasValue) return NotFound();//Verify that it has a Value assigned

                TasK TaskToEdit = repoTask.GetById(idTask);
                EditTaskViewModel TaskToEditVM = new EditTaskViewModel();
                
                if (isAdmin()){//If it is Admin it can editarla
                    TaskToEditVM = EditTaskViewModel.FromTask(TaskToEdit);
                }else{
                    UseR loggedInUser = repoLogin.TakeUser(HttpContext.Session.GetString("Name"),HttpContext.Session.GetString("Password"));
                    if (loggedInUser.Id == repoTask.GetById(idTask).Propietary.Id){
                        TaskToEditVM = EditTaskViewModel.FromTask(TaskToEdit);//convert from Model to ViewModel
                    }else{
                        _logger.LogWarning("You must be an administrator to perform the action");
                        return NotFound();
                    }
                }
                TaskToEditVM.Boards = repoBoard.GetAll();
                TaskToEditVM.Users = repoUser.GetAll();
                return View(TaskToEditVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method EditTask from the controller TasK: {ex.ToString()}");
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult EditTaskFromForm(EditTaskViewModel TaskToEditVM){
            try
            {
                if(!ModelState.IsValid) return RedirectToAction("Index","Login");
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                TasK TaskToEdit = TasK.FromEditTaskViewModel(TaskToEditVM);
                repoTask.Update(TaskToEdit);
                return RedirectToAction("Index", "UseR");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method EditTaskFromForm from the controller TasK: {ex.ToString()}");
                return BadRequest();
            } 
        }

        [HttpGet]
        public IActionResult DeleteTask(int? idTask){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                if(!idTask.HasValue) return NotFound();
                TasK TaskToDelete = repoTask.GetById(idTask);

                if (isAdmin()){//If it is Admin it can Borrarla
                    return View(TaskToDelete);
                }else{
                    UseR loggedInUser = repoLogin.TakeUser(HttpContext.Session.GetString("Name"),HttpContext.Session.GetString("Password"));
                    if (loggedInUser.Id == repoTask.GetById(idTask).Propietary.Id){
                        return View(TaskToDelete);
                    }else{
                        _logger.LogWarning("You must be an administrator to perform the action");
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method DeleteTask from the controller TasK: {ex.ToString()}");
                return BadRequest();
            } 
        }
        [HttpPost]
        public IActionResult DeleteTaskFromForm(int? idTaskToDelete){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                repoTask.Remove(idTaskToDelete);
                return RedirectToAction("Index", "UseR");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method DeleteTask from the controller TasK: {ex.ToString()}");
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult AssignTask(int? idTask){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                if(!idTask.HasValue) return NotFound();
                TasK TaskSelected = repoTask.GetById(idTask);
                AssignTaskViewModel TaskSelectedVM = new AssignTaskViewModel();

                if (isAdmin()){//If it is Admin it can Asignarla
                    TaskSelectedVM = AssignTaskViewModel.FromTask(TaskSelected);
                }else{
                    UseR loggedInUser = repoLogin.TakeUser(HttpContext.Session.GetString("Name"),HttpContext.Session.GetString("Password"));
                    if (loggedInUser.Id == repoTask.GetById(idTask).Propietary.Id){
                        TaskSelectedVM = AssignTaskViewModel.FromTask(TaskSelected);
                    }else{
                        _logger.LogWarning("You must be an administrator to perform the action");
                        return NotFound();
                    }
                }
                
                List<UseR> usersInBD = repoUser.GetAll();
                foreach (var user in usersInBD)//Gets the list of UseR IDs available to select
                {
                    (TaskSelectedVM.IdUsers).Add(user.Id);
                }
                return View(TaskSelectedVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method AssignTask from the controller TasK: {ex.ToString()}");
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult AssignTaskFromForm(AssignTaskViewModel TaskSelectedVM){
            try
            {
                if(!ModelState.IsValid) return RedirectToAction("Index","Login");
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                repoTask.Assign(TaskSelectedVM.Id,TaskSelectedVM.IdAssignedUser);
                return RedirectToAction("Index", "UseR");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method AssignTaskFromForm from the controller TasK: {ex.ToString()}");
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult ChangeTaskStatus(int? idTask){  
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                if(!idTask.HasValue) return NotFound();
                TasK TaskToEdit = repoTask.GetById(idTask);
                EditTaskViewModel TaskToEditVM = new EditTaskViewModel();
                
                if (isAdmin()){//If it is Admin it can change the status
                    TaskToEditVM = EditTaskViewModel.FromTask(TaskToEdit);
                }else{
                    UseR loggedInUser = repoLogin.TakeUser(HttpContext.Session.GetString("Name"),HttpContext.Session.GetString("Password"));
                    if ((loggedInUser.Id == repoTask.GetById(idTask).Propietary.Id) || (loggedInUser.Id == repoTask.GetById(idTask).Assigned.Id)){
                        TaskToEditVM = EditTaskViewModel.FromTask(TaskToEdit);
                    }else{
                        _logger.LogWarning("You must be an administrator to perform the action");
                        return NotFound();
                    }
                }
                return View(TaskToEditVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method ChangeTaskStat from the controller TasK: {ex.ToString()}");
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult ChangeStatusFromForm(ChangeTaskStatViewModel TaskToEditVM){
            try
            {
                if(!ModelState.IsValid) return RedirectToAction("Index","Login");
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                TasK TaskToEdit = TasK.FromChangeTaskStatViewModel(TaskToEditVM);
                repoTask.ChangeStatus(TaskToEdit);
                return RedirectToAction("Index", "UseR");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method ChangeStatusFromForm from the controller TasK: {ex.ToString()}");
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