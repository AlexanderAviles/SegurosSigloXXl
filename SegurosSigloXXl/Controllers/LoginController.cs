using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SegurosSigloXXl.Models;
using SegurosSigloXXl.Filtros;

namespace SegurosSigloXXl.Controllers
{
    public class LoginController : Controller
    {
        #region VISTA LOGIN
        // GET: Login
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            return View();
        }
        #endregion FIN VISTA LOGIN

        #region VALIDACION LOGIN
        [HttpPost]
        public ActionResult Login(string Usuario, string Contrasenia)
        {
            try
            {
                Usuarios oUser;
                Clientes oCliente;
                using (Models.SegurosSigloXXlEntities db = new Models.SegurosSigloXXlEntities())
                {
                    oUser = (from d in db.Usuarios
                             where d.NombreUsuario.Trim() == Usuario && d.Contrasenia == Contrasenia.Trim()
                             select d).FirstOrDefault();
                    oCliente = (from d in db.Clientes
                                where d.Correo.Trim() == Usuario
                                select d).FirstOrDefault();
                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario ó contraseña invalido";

                        return View();
                    }
                    else
                    {
                        Session["Usuario"] = oUser;
                        Session["Cliente"] = oCliente;
                        Session["PrimeraVez"] = "true";
                        FormsAuthentication.SetAuthCookie(oUser.NombreUsuario, false);
                    }
                }
                return RedirectToAction("Principal", "Principal");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }
        #endregion FIN VALIDACION LOGIN

        #region CERRAR SESION
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session["Usuario"] = null;
            Session["Cliente"] = null;
            Session["PrimeraVez"] = null;
            return RedirectToAction("Login", "Login");
        }
        #endregion FIN CERRAR SESION

        public ActionResult Bienvenida()
        {
             Clientes oCliente;
            string NombreCompleto = "";
            if (Session["Cliente"] != null)
            {
                oCliente = (Clientes)Session["Cliente"];
                NombreCompleto = oCliente.Nombre + " " + oCliente.PrimerApellido + " " + oCliente.SegundoApellido;

                return Json(new
                {
                    nombre = NombreCompleto,
                    sesion = true
                }); 
            }
            return Json(new
            {
                nombre = "",
            });
        }

    }
}