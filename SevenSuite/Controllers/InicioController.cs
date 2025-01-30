using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SevenSuite.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string usuario, string clave)
        {
         
            if (usuario == "admin" && clave == "1234" )
            {
                ViewData["Mensaje"] = "Usuario no encontrado..";
                return View();
            }



            return RedirectToAction("Index", "Home");
        }
    }
}
