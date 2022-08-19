using SegurosSigloXXl.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SegurosSigloXXl.Models;
namespace SegurosSigloXXl.Filtros
{
    public class VerificaSession : ActionFilterAttribute
    {
        readonly private string TipoUsuario;
        private Usuarios oUsurio;

        public VerificaSession(string Tipo)
        {
            TipoUsuario = Tipo;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
            try
            {
                base.OnActionExecuted(filterContext);
                oUsurio = (Usuarios)HttpContext.Current.Session["Usuario"];

                if(oUsurio == null)
                {
                    if(filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/Login");
                    }
                }
                else
                {
                    Usuarios usuario = oUsurio as Usuarios;

                    if(usuario.TipoUsuario == this.TipoUsuario)
                    {
                        
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("~/Otros/Sinpermiso");
                    }
                }
            }catch(Exception)
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
            }
            
        }
    }
}