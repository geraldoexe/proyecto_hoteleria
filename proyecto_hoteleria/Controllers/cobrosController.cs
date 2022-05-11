using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_hoteleria.Controllers
{
    public class cobrosController : Controller
    {
        // GET: cobros
        public ActionResult facturacion()
        {
            return View("/Views/Check_out/Check_out.cshtml");
        }


        //, string pasaporte, int precio, int iva, int gastosextras, string pago, string tarjeta
        public ActionResult generarcobro(string nombre, string apellidos, string pasaporte, int precio, int iva, int gastosextras, string pago, string tarjeta)
        {
            ViewBag.nombre = nombre;
            ViewBag.apellidos = apellidos;
            ViewBag.pasaporte = pasaporte;
            ViewBag.precio = precio;
            ViewBag.iva = iva;
            ViewBag.gastosextras = gastosextras;
            ViewBag.pago = pago;
            ViewBag.tarjeta = tarjeta;

            return View("/Views/form/cobros.cshtml");
        }

        //REPORTE A FINANZAS
        public ActionResult reporte_finanzas(string nombre, string apellidos, string pasaporte, int precio, int iva, int gastosextras, string pago, string tarjeta)
        {
            ViewBag.nombre = nombre;
            ViewBag.apellidos = apellidos;
            ViewBag.pasaporte = pasaporte;
            ViewBag.precio = precio;
            ViewBag.iva = iva;
            ViewBag.gastosextras = gastosextras;
            ViewBag.pago = pago;
            ViewBag.tarjeta = tarjeta;

            return View("/Views/Check_out/reporte_finanzas.cshtml");

        }
    }
}