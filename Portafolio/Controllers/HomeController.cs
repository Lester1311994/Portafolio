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

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos)
        {
            _logger = logger;
            _repositorioProyectos = repositorioProyectos;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
