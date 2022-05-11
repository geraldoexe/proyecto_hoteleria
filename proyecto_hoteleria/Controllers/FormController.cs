using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_hoteleria.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult agendarReserva()
        {
            return View("/Views/Agendar_Reserva/Agendar_Reserva.cshtml");
        }

        public ActionResult saveform(string rut, string nombre, string apellidos, string mail, string ciudad, string pais)
        {
            ViewBag.rut = rut;
            ViewBag.nombre = nombre;
            ViewBag.apellidos = apellidos;
            ViewBag.mail = mail;
            ViewBag.ciudad = ciudad;
            ViewBag.pais = pais;

            return View("/Views/Reservaciones/Reservaciones.cshtml");
        }

        public ActionResult Contacto()
        {
            return View("/Views/Home/Contact.cshtml");
        }

        public ActionResult savecontact(string nombre, string apellido, string mail, string telefono, string pais)
        {
            ViewBag.nombre = nombre;
            ViewBag.apellido = apellido;
            ViewBag.mail = mail;
            ViewBag.telefono = telefono;
            ViewBag.pais = pais;

            return View("/Views/form/contacto.cshtml");
        }

        public ActionResult savecontact2(string texto)
        {
            char separador = '.';
            string[] arreg = texto.Split(separador);
            int largo = arreg.Length;
            string x = "";
            for (int i = 0; i < largo; i++)
            {
                x = x + "<td>" + arreg[i] + "</td>";
            }
            ViewBag.res = x;
            ViewBag.largo = largo;

            return View("/Views/form/contacto.cshtml");
        }

        public ActionResult reserva01()
        {
            return View("/Views/Agendar_Reserva/Agendar_Reserva.cshtml");
        }


     }
    
}