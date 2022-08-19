using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SegurosSigloXXl.Models;
namespace SegurosSigloXXl.Controllers
{

    [Authorize]
    public class PrincipalController : Controller
    {
        private Usuarios oUsurio;
        private Clientes oCliente;
        // GET: Principal
        public ActionResult Principal()
        {

            oUsurio = (Usuarios)Session["Usuario"];
            oCliente = (Clientes)Session["Cliente"];
            string PrimeraVez = (string)Session["PrimeraVez"];
            if (oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                ViewBag.NombreCliente = oCliente.Nombre + " " + oCliente.PrimerApellido + " " + oCliente.SegundoApellido;
                ViewBag.PrimeraVez = PrimeraVez;
                return View();
            }
            return View();

        }


    }
}
