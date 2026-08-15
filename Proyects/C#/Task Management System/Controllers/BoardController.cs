using Microsoft.AspNetCore.Mvc;

using Proyect.Repositories;
using Proyect.Models;
using Proyect.ViewModels;

namespace Proyect.Controllers{
    public class BoardController: Controller{
        private readonly IBoardRepository repoBoard;
        private readonly ITaskRepository repoTask;
        private readonly IUserRepository repoUser;
        private readonly ILoginRepository repoLogin;
        private readonly ILogger<HomeController> _logger;
        public BoardController(ILogger<HomeController> logger, IBoardRepository boardRepo, IUserRepository userRepo, ITaskRepository TaskRepo, ILoginRepository logRepo) 
        {
            _logger = logger;
            repoTask = TaskRepo;
            repoBoard = boardRepo;
            repoUser = userRepo;
            repoLogin = logRepo;
        }

        public IActionResult Index(int? idUser){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }

                List<Board> boards = new List<Board>();

                if (isAdmin()){
                    if (idUser.HasValue){
                        boards = repoBoard.GetAllByOwnerUser(idUser).Union(repoBoard.GetAllByAsignedTask(idUser)).GroupBy(t => t.Id).Select(group => group.First()).ToList();
                    }else{
                        boards = repoBoard.GetAll();
                    }
                }else{
                    UseR loggedInUser = repoLogin.TakeUser(HttpContext.Session.GetString("Name"),HttpContext.Session.GetString("Password"));
                    if (idUser == loggedInUser.Id){
                        boards = repoBoard.GetAllByOwnerUser(idUser).Union(repoBoard.GetAllByAsignedTask(idUser)).GroupBy(t => t.Id).Select(group => group.First()).ToList();   
                    }else{
                        _logger.LogWarning("You must be an administrator to perform the action");
                        return NotFound();
                    }
                }
    
                List<ListBoardViewModel> boardsListVM = ListBoardViewModel.FromBoard(boards);
                return View(boardsListVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in Index method of Board handler: {ex.ToString()}");
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult AddBoard(){
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

                CreateBoardViewModel newBoardVM = new CreateBoardViewModel();
                newBoardVM.Users = repoUser.GetAll();
                
                return View(newBoardVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in AddBoard method of Board driver: {ex.ToString()}");
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult AddBoardFromForm(CreateBoardViewModel newBoardVM){
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

                Board newBoard = Board.FromCreateBoardViewModel(newBoardVM);
                repoBoard.Create(newBoard);
                return RedirectToAction("Index", new { idUser = newBoard.Propietary.Id });//Redirects to the index with the UseR id
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in Board driver AddBoardFromForm method: {ex.ToString()}");
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult EditBoard(int? idBoard){
            try
            {   
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }
                if(!idBoard.HasValue) return NotFound();//Verify that it has a Value assigned
                
                Board boardToEdit = repoBoard.GetById(idBoard);//I get the DB board with the Base Model
                EditBoardViewModel boardToEditVM = new EditBoardViewModel();//Initial instance of ViewModel
                
                if (isAdmin()){//If are Admin you can Edit
                    boardToEditVM = EditBoardViewModel.FromBoard(boardToEdit);
                }else{
                    //Check if the id of the logged in user is the same as that of the user who owns the board you want to edit
                    UseR loggedInUser = repoLogin.TakeUser(HttpContext.Session.GetString("Name"),HttpContext.Session.GetString("Password"));
                    if (loggedInUser.Id == repoBoard.GetById(idBoard).Propietary.Id){
                        boardToEditVM = EditBoardViewModel.FromBoard(boardToEdit);//Convert from Model to ViewModel
                    }else{
                        _logger.LogWarning("You must be an administrator to perform the action");
                        return NotFound();
                    }
                }

                boardToEditVM.Users = repoUser.GetAll();//Gets users to select
    
                return View(boardToEditVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method EditBoard from the controller Board: {ex.ToString()}");
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult EditBoardFromForm(EditBoardViewModel boardToEditVM){
            try
            {
                if(!ModelState.IsValid) return RedirectToAction("Index","Login");
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }
                Board boardToEdit = Board.FromEditBoardViewModel(boardToEditVM);
                repoBoard.Update(boardToEdit);
                return RedirectToAction("Index", new { idUser = boardToEdit.Propietary.Id});
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method EditBoardFromForm from the controller Board: {ex.ToString()}");
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult DeleteBoard(int? idBoard){
            try
            {   
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }
                
                if(!idBoard.HasValue) return NotFound();
                Board boardToDelete = repoBoard.GetById(idBoard);

                if (isAdmin()){//If it is Admin it can Delete
                    return View(boardToDelete);
                }else{
                    UseR loggedInUser = repoLogin.TakeUser(HttpContext.Session.GetString("Name"),HttpContext.Session.GetString("Password"));
                    if (loggedInUser.Id == repoBoard.GetById(idBoard).Propietary.Id){
                        return View(boardToDelete);
                    }else{
                        _logger.LogWarning("You must be an administrator to perform the action");
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method DeleteBoard from the controller Board: {ex.ToString()}");
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult DeleteBoardFromForm(int? idBoardToDelete){
            try
            {
                if(!isLogin())
                {
                    TempData["Message"] = "You must log in to access this page.";
                    return RedirectToAction("Index", "Login");
                }
                repoBoard.Remove(idBoardToDelete);
                return RedirectToAction("Index", "UseR");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request in method DeleteBoardFromForm from the controller Board: {ex.ToString()}");
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