using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace SevenSuite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Guarda sesion
            List<UsuarioSesionDTO> lista = new List<UsuarioSesionDTO>();
            lista.Add(new UsuarioSesionDTO
            {
                id_usuario=1,
                usuario = "admin"
            });

            //HttpContext.Session.SetObject("dataUserSession", lista);

            return View();
        }
    }
}
