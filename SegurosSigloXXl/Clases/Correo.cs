using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail; // Libreria utilizada para enviar el correo.
using System.Net; // Libreria utilizada para enviar el correo.
namespace SegurosSigloXXl.Clases
{
    public class Correo
    {
        public Correo()
        {

        }

        public void EnviarCorreoClienteNuevo(string pCorreoElectronico, string pCliente, string pContrasenia)
        {
            // Cuerpo del correo electronico
            string body =
            "<body>" +
                "<h1>Seguros El Equipo del Siglo XXI.</h1>" +
                $"<h2><b>Estimado cliente:</b> {pCliente}</h2>" +
                "<span>Gracias por confiar en en Seguros el Equipo del Siglo XXI. Para nosotros es un placer servirle.</span>" +
                "<br/><span>A continuación, sus credenciales para ingresar a la aplicación:</span>" +
                $"<br/><h3>Sitio web:</b> www.segurossigloxxl.com</h3>" +
                $"<h3>Usuario: {pCorreoElectronico}" +
                $"<h3>Contraseña: {pContrasenia}</h3>" +
                "<br/><br/><span>Seguros El Equipo del Siglo XXI le desea un buen dia.</span>" +
                //"<br/><br/><img src='"+img+"' height='250px' width='250px' />" +
                "<br/><br/><br/><br/><span><b>Mensaje autogenerado, por favor no responder.</b></span>" +
            "</body>";

            // Servidor del correo electronico que se utiliza para enviar el correo.
            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            // Credenciales del correo electronico del Centro medico, utilizado para enviar correos
            smtp.Credentials = new NetworkCredential("segurossigloxxl@hotmail.com", "L3$$Swert.2022");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            MailMessage mail = new MailMessage();
            // Correo electronico que se enviara al cliente con el motivo
            mail.From = new MailAddress("segurossigloxxl@hotmail.com", "Su cuenta en Seguros El Equipo del Siglo XXI.");

            // Cuerpo del correo anteriormente creado
            mail.To.Add(new MailAddress(pCorreoElectronico));
            mail.Subject = "Querido usuario";
            mail.IsBodyHtml = true;
            mail.Body = body;
            // Envia el correo electronico
            smtp.Send(mail);

        }
    }
}