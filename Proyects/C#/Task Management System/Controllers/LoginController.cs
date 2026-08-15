using Microsoft.AspNetCore.Mvc;

using Proyect.ViewModels;
using Proyect.Models;
using Proyect.Repositories;

namespace Proyect.Controllers{
    public class LoginController: Controller{
        private readonly ILoginRepository repoLogin;
        private readonly ILogger<HomeController> _logger;
        public LoginController(ILogger<HomeController> logger, ILoginRepository logRepo) 
        {
            _logger = logger;
            repoLogin = logRepo;
        }

        public IActionResult Index()
        {
            try
            {
                LoginViewModel login = new LoginViewModel();
                return View(login);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error trying to log in: {ex.ToString()}");
                return BadRequest();
            }
        }
        
        [HttpPost]
        public IActionResult ValidateUser(LoginViewModel login)
        {
            if(repoLogin.AutenticateUser(login.Name,login.Password)){
                UseR userToLogin = repoLogin.TakeUser(login.Name,login.Password);
                
                _logger.LogInformation($"The UseR {userToLogin.Name} entered correctly");

                loginUser(userToLogin);
                var routeToRedirect = new { controller = "UseR", action = "Index" };
                return RedirectToRoute(routeToRedirect);
                
            }else{
                _logger.LogWarning($"Invalid access attempt - UseR: {login.Name} Password entered: {login.Password}");
                return RedirectToAction("Index");
            }
        }

        private void loginUser(UseR userToLogin)
        {
            HttpContext.Session.SetString("Name", userToLogin.Name);
            HttpContext.Session.SetString("Password", userToLogin.Password);
            HttpContext.Session.SetString("AccessLevel", Convert.ToString(userToLogin.AccessLevel));
        }

        public IActionResult Unlog()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}