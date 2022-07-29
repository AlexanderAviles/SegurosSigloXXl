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
        // GET: Principal
        public ActionResult Principal()
        {

            oUsurio = (Usuarios)Session["Usuario"];
            if(oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                return View();
            }
            return View();

        }

    }
}
