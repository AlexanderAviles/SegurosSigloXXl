using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SegurosSigloXXl.Models;
using SegurosSigloXXl.BLSeguroSigloXXl;
using SegurosSigloXXl.Clases;
using SegurosSigloXXl.Filtros;

namespace SegurosSigloXXl.Controllers
{
    [Authorize]
    public class AdiccionesPorClientesController : Controller
    {
        readonly SegurosSigloXXlEntities DBSeguros = new SegurosSigloXXlEntities();
        readonly BLCLientes Cliente = new BLCLientes();
        readonly Correo CorreoElectronico = new Correo();
        private Usuarios oUsurio;
        // GET: AdiccionesPorClientes
        public ActionResult AdiccionesPorClientes()
        {
            oUsurio = (Usuarios)Session["Usuario"];
            if (oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                return View();
            }
            return View();
        }
    }
}