using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Services;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos _repositorioProyectos;
        private readonly IServiceEmail _serviceEmail;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos,IServiceEmail serviceEmail)
        {
            _logger = logger;
            _repositorioProyectos = repositorioProyectos;
            _serviceEmail = serviceEmail;
        }

        public IActionResult Index()
        {
            var listaProyectos = _repositorioProyectos.ListaProyectos().ToList().Take(3);
            HomeIndexViewModel proyectos = new HomeIndexViewModel()
            {
                Proyectos = listaProyectos
            };

            return View(proyectos);
        }

        public IActionResult Proyectos()
        {
            var proyectos = _repositorioProyectos.ListaProyectos().ToList();
            return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(ContactoViewModel contacto)
        {
            _serviceEmail.SendEmail(contacto);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
