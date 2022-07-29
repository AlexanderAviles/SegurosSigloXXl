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
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Login(string Usuario, string Contrasenia)
        {
            try
            {
                Usuarios oUser;
                using (Models.SegurosSigloXXlEntities db = new Models.SegurosSigloXXlEntities())
                {
                    oUser = (from d in db.Usuarios
                                 where d.NombreUsuario.Trim() == Usuario && d.Contrasenia == Contrasenia.Trim()
                                 select d).FirstOrDefault();
                   
                    if(oUser == null)
                    {
                        ViewBag.Error = "Usuario ó contraseña invalido";
                        return View();
                    }
                    else
                    {
                        Session["Usuario"] = oUser;
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

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session["Usuario"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}