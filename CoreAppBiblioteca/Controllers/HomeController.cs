using CoreAppBiblioteca.Filters;
using CoreAppBiblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CoreAppBiblioteca.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

     
        public IActionResult Login(bool showerror)
        {
            if(HttpContext.Session.GetString("LogSession") != null)
            {
                return RedirectToAction("Index");
            }
            return View(new LoginUtente(showerror));
        }

        [HttpPost]
        public IActionResult Login(Utente u)
        {
            var log = DB.Login(u.UserName);
            if (log != "0")
            {
                HttpContext.Session.SetString("LogSession", log);
            }
            else
            {
                HttpContext.Session.Remove("LogSession");
                return RedirectToAction("Login", new {showerror = true});
            }

            return RedirectToAction("Index");
        }
        [AuthFilter]
        public IActionResult Index()
        {
            return View(DB.GetList());
        }
        [AuthFilter]
        public IActionResult Detail(int id)
        {
            var l = DB.GetLibro(id);
            return View(l);
        }
        [HttpPost]
        [AuthFilter]
        public IActionResult PrendiLibro(Libro libro)
        {
            var l = DB.GetLibroByName(libro.Titolo);
            if (l != null)
            {
                // alert?
            }
            else
            {
                // alert?
            }
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}