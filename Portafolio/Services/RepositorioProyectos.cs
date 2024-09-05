using Portafolio.Models;

namespace Portafolio.Services
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ListaProyectos();
    }
    public class RepositorioProyectos: IRepositorioProyectos
    {
        public List<Proyecto> ListaProyectos()
        {
            return new List<Proyecto>()
            {
                new() {
                    Titulo = "Amazon",
                    Descripcion = "E-Commerce realizado en ASP.NET Core",
                    Link = "https://www.amazon.com/",
                    ImagenURL = "/imagenes/amazon.png"
                },
                new() {
                    Titulo = "New York Times",
                    Descripcion = "Página de noticias en React",
                    Link = "https://www.nytimes.com/",
                    ImagenURL = "/imagenes/nytimes.jpg"
                },
                new() {
                        Titulo = "Reddit",
                        Descripcion = "Red social para compartir en comunidades",
                        Link = "https://www.reddit.com/",
                        ImagenURL = "/imagenes/reddit.png"
                    },
                new() {
                    Titulo = "Steam",
                    Descripcion = "Tienda en línea para compartir videojuegos",
                    Link = "https://store.steampowered.com/",
                    ImagenURL = "/imagenes/steam.jpg"
                }
            };
        }
    }
}
