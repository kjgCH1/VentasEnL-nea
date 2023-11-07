using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Dominio;
using VentasEnLíneaVista.Data;
using Entidades;

namespace VentasEnLíneaVista.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else {
                return RedirectToAction("Index", "Home");
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cedula, string contrasena)
        {
            UsuarioData data = new UsuarioData();
            Usuario usuario = data.Login(cedula, contrasena);
            RolData rolData = new RolData();
            Rol rol = rolData.busacarRolId(usuario.Rol);
            
            if (usuario.Id>0)
            {
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("cedula", usuario.Cedula)
                };

                
                claims.Add(new Claim(ClaimTypes.Role,rol.Nombre));
               
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = "Algo salio mal, cedula o contraseña invalidas";
                ViewBag.etiqueta = "alert alert-danger";
                return View();
            }

        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
    