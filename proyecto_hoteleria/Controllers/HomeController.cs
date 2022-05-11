using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_hoteleria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Reserva()
        {
            return View("/Views/Reservas/Reserva.cshtml");
        }
        public ActionResult El_Hotel()
        {
            return View("/Views/El_Hotel/El_Hotel.cshtml");
        }
        public ActionResult Agendar_Reserva()
        {
            return View("/Views/Agendar_Reserva/Agendar_Reserva.cshtml");
        }

        public ActionResult Usuarios()
        {
            return View("/Views/Usuarios/Usuarios.cshtml");
        }
        public ActionResult Checkin_Checkout()
        {
            return View("/Views/Checkin_Checkout/Checkin_Checkout.cshtml");
        }
        public ActionResult Reservaciones()
        {
            return View("/Views/Reservaciones/Reservaciones.cshtml");
        }
        public ActionResult Check_in()
        {
            return View("/Views/Check_in/Check_in.cshtml");
        }
        public ActionResult Check_out()
        {
            return View("/Views/Check_out/Check_out.cshtml");
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Restaurantes()
        {
            return View("/Views/Home/Restaurantes.cshtml");
        }
        public ActionResult Habitaciones()
        {
            return View("/Views/Home/Habitaciones.cshtml");
        }
        public ActionResult Fotos()
        {
            return View("/Views/Home/Fotos.cshtml");
        }
    }
}
