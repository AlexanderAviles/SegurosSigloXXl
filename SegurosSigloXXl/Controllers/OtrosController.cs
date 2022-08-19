using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SegurosSigloXXl.Controllers
{
    public class OtrosController : Controller
    {
        // GET: Otros
        public ActionResult SinPermiso()
        {
            ViewBag.Message = "Usted no tiene permisos para ver esta pagina";
            return View();
        }
    }
}