using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace proyecto_hoteleria.Controllers
{
    public class databaseController : Controller
    {
        // GET: database
        public ActionResult Agendar_Reserva()
        {
            return View("/Views/Agendar_Reserva/Agendar_Reserva.cshtml");
        }

        public ActionResult save_database(string rut, string nombre, string apellidos, string mail, string ciudad, string pais, string tiporeserva, string diareserva, string tipohabitacion)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_hotel_system;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            var sentencia = new SqlCommand();
            sentencia.CommandType = System.Data.CommandType.Text;
            if (rut == "" || nombre == "" || apellidos == "" || mail == "" || ciudad == "" || pais == "" || tiporeserva == "" || diareserva == "" || tipohabitacion == "")
            {
                ViewBag.Error = "Error - Faltan Datos";
                return View("/Views/Agendar_Reserva/Agendar_Reserva.cshtml");
            }
            else
            {
                sentencia.CommandText = "insert into reservaciones (rut,nombre,apellidos,mail,ciudad, pais, tiporeserva, diareserva, tipohabitacion) values (@prut, @pnombre, @papellidos, @pmail,@pciudad,@ppais, @ptiporeserva, @pdiareserva, @ptipohabitacion)";
                sentencia.Parameters.Add(new SqlParameter("prut", rut));
                sentencia.Parameters.Add(new SqlParameter("pnombre", nombre));
                sentencia.Parameters.Add(new SqlParameter("papellidos", apellidos));
                sentencia.Parameters.Add(new SqlParameter("pmail", mail));
                sentencia.Parameters.Add(new SqlParameter("pciudad", ciudad));
                sentencia.Parameters.Add(new SqlParameter("ppais", pais));
                sentencia.Parameters.Add(new SqlParameter("ptiporeserva", tiporeserva));
                sentencia.Parameters.Add(new SqlParameter("pdiareserva", diareserva));
                sentencia.Parameters.Add(new SqlParameter("ptipohabitacion", tipohabitacion));
                sentencia.Connection = con;

                var result = sentencia.ExecuteNonQuery();
                var mensaje = "";
                if (result > 0)
                {
                    mensaje = "REGISTRO DE RESERVA ENVIADO Y GUARDADO CON EXITO";
                }
                else
                {
                    mensaje = "ERROR";
                }
                ViewBag.mensaje = mensaje;

                return View("/Views/Agendar_Reserva/Agendar_Reserva.cshtml");
            }
        }

        public ActionResult show_database()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_hotel_system;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select rut, nombre, apellidos, mail, ciudad, pais, tiporeserva, diareserva, tipohabitacion from reservaciones";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "<table border=1>";
            mensaje = mensaje + "<tr><td>RUT<td>NOMBRE<td>APELLIDOS<td>MAIL<td>CIUDAD<td>PAIS<td>TIPORESERVA<td>DIARESERVA<td>TIPOHABITACION</td></tr>";
            while (dr.Read())
            {
                mensaje = mensaje + "<tr>" + "<td >" + dr["rut"].ToString() + "<td >" + dr["nombre"].ToString() + "<td > " + dr["apellidos"].ToString() + "<td >" + dr["mail"].ToString() + "<td >" + dr["ciudad"].ToString() + "<td >" + dr["pais"].ToString() + "<td >" + dr["tiporeserva"].ToString() + "<td >" + dr["diareserva"].ToString() + "<td >" + dr["tipohabitacion"].ToString() + "</td></tr>";
            }
            mensaje = mensaje + "</table>";
            ViewBag.mensaje = mensaje;
            return View("/Views/Check_in/Check_in.cshtml");

        }


        public ActionResult Check_in()
        {
            return View("/Views/Check_in/Check_in.cshtml");
        }

        public ActionResult save_checkin(string id_checkin, string rut, string direccion, string fecha_llegada, int noches, string fecha_salida, int adultos, int niños, int n_habitaciones, string tipohabitacion, int numero_habitacion, int precio, string pago, string n_tarjetacredito)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_hotel_system;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            var sentencia = new SqlCommand();
            if (id_checkin == "" || rut == "" || direccion == "" || fecha_llegada == "" || noches == 0 || fecha_salida == "" || adultos == 0 || n_habitaciones == 0 || tipohabitacion == "" || numero_habitacion == 0 || precio == 0 || pago == "" || n_tarjetacredito == "")
            {
                ViewBag.Error = "Error - Faltan Datos";
                return View("/Views/Check_in/Check_in.cshtml");
            }

            sentencia.CommandType = System.Data.CommandType.Text;
            sentencia.CommandText = "insert into checkin (id_checkin, rut, direccion, fecha_llegada, noches, fecha_salida, adultos, niños, n_habitaciones, tipohabitacion, numero_habitacion, precio, pago, n_tarjetacredito) values (@pid_checkin, @prut, @pdireccion, @pfecha_llegada, @pnoches, @pfecha_salida, @padultos, @pniños, @pn_habitaciones, @ptipohabitacion, @pnumero_habitacion, @pprecio, @ppago, @pn_tarjetacredito)";
            sentencia.Parameters.Add(new SqlParameter("pid_checkin", id_checkin));
            sentencia.Parameters.Add(new SqlParameter("prut", rut));
            sentencia.Parameters.Add(new SqlParameter("pdireccion", direccion));
            sentencia.Parameters.Add(new SqlParameter("pfecha_llegada", fecha_llegada));
            sentencia.Parameters.Add(new SqlParameter("pnoches", noches));
            sentencia.Parameters.Add(new SqlParameter("pfecha_salida", fecha_salida));
            sentencia.Parameters.Add(new SqlParameter("padultos", adultos));
            sentencia.Parameters.Add(new SqlParameter("pniños", niños));
            sentencia.Parameters.Add(new SqlParameter("pn_habitaciones", n_habitaciones));
            sentencia.Parameters.Add(new SqlParameter("ptipohabitacion", tipohabitacion));
            sentencia.Parameters.Add(new SqlParameter("pnumero_habitacion", numero_habitacion));
            sentencia.Parameters.Add(new SqlParameter("pprecio", precio));
            sentencia.Parameters.Add(new SqlParameter("ppago", pago));
            sentencia.Parameters.Add(new SqlParameter("pn_tarjetacredito", n_tarjetacredito));

            sentencia.Connection = con;

            var result2 = sentencia.ExecuteNonQuery();
            var mensaje2 = "";
            if (result2 > 0)
            {
                mensaje2 = "REGISTRO DE CHECK_IN GUARDADO CON EXITO";
            }
            else
            {
                mensaje2 = "ERROR";
            }
            ViewBag.mensaje2 = mensaje2;

            return View("/Views/Check_in/Check_in.cshtml");
        }



        public ActionResult show_checkin()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_hotel_system;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select id_checkin, rut, direccion, fecha_llegada, noches, fecha_salida, adultos, niños, n_habitaciones, tipohabitacion, numero_habitacion, precio, pago, n_tarjetacredito from checkin";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje2 = "<table border=1>";
            mensaje2 = mensaje2 + "<tr><td>ID CHECK IN<td>RUT<td>DIRECCION<td>FECHA LLEGADA<td>NOCHES<td>FECHA SALIDA<td>ADULTOS<td>NIÑOS<td>CANT HABS<td>TIPO HAB.<td>N° DE HAB<td> PRECIO <td>PAGO<td> N° TARJ</td></tr>";
            while (dr.Read())
            {
                mensaje2 = mensaje2 + "<tr>" + "<td >" + dr["id_checkin"].ToString() + "<td >" + dr["rut"].ToString() + "<td > " + dr["direccion"].ToString() + "<td >" + dr["fecha_llegada"].ToString() + "<td >" + dr["noches"].ToString() + "<td >" + dr["fecha_salida"].ToString() + "<td >" + dr["adultos"].ToString() + "<td >" + dr["niños"].ToString() + "<td >" + dr["n_habitaciones"].ToString() + "<td >" + dr["tipohabitacion"].ToString() + "<td >" + dr["numero_habitacion"].ToString() + "<td >" + dr["precio"].ToString() + "<td >" + dr["pago"].ToString() + "<td >" + dr["n_tarjetacredito"].ToString() + "</td></tr>";
            }
            mensaje2 = mensaje2 + "</table>";
            ViewBag.mensaje2 = mensaje2;
            return View("/Views/Check_in/registro_huespedes.cshtml");

        }


        //METODO PARA ELIMINACION DE REGISTRO DE CHECKIN
        public ActionResult delete(string rutx)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_hotel_system;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            var sentencia = new SqlCommand();
            sentencia.CommandType = System.Data.CommandType.Text;
            sentencia.CommandText = "delete from checkin where rut = @prut";
            sentencia.Parameters.Add(new SqlParameter("prut", rutx));

            sentencia.Connection = con;

            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result > 0)
            {
                mensaje = "REGISTRO ELIMINADO CON EXITO";
            }
            else
            {
                mensaje = "ERROR";
            }
            ViewBag.mensaje = mensaje;

            return View("/Views/Check_out/Check_out.cshtml");

        }

        //METODO PARA ACTUALLIZAR DATOS DE RESERVA 
        public ActionResult update(string rut, string nombre, string apellidos, string mail, string ciudad, string pais, string tiporeserva, string diareserva, string tipohabitacion)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_hotel_system;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            var sentencia = new SqlCommand();
            if (rut == "" || nombre == "" || apellidos == "" || mail == "" || ciudad == "" || pais == "" || tiporeserva == "" || diareserva == "" || tipohabitacion == "")
            {
                ViewBag.Error = "Error - Faltan Datos";
                return View("/Views/Reservaciones/Reservaciones.cshtml");
            }
            else
            {
                sentencia.CommandType = System.Data.CommandType.Text;
                sentencia.CommandText = "update reservaciones set rut=@prut, nombre=@pnombre, apellidos=@papellidos, mail=@pmail, ciudad=@pciudad, pais=@ppais, tiporeserva=@ptiporeserva, diareserva=@pdiareserva, tipohabitacion=@ptipohabitacion where rut=@prut";
                sentencia.Parameters.Add(new SqlParameter("prut", rut));
                sentencia.Parameters.Add(new SqlParameter("pnombre", nombre));
                sentencia.Parameters.Add(new SqlParameter("papellidos", apellidos));
                sentencia.Parameters.Add(new SqlParameter("pmail", mail));
                sentencia.Parameters.Add(new SqlParameter("pciudad", ciudad));
                sentencia.Parameters.Add(new SqlParameter("ppais", pais));
                sentencia.Parameters.Add(new SqlParameter("ptiporeserva", tiporeserva));
                sentencia.Parameters.Add(new SqlParameter("pdiareserva", diareserva));
                sentencia.Parameters.Add(new SqlParameter("ptipohabitacion", tipohabitacion));
                
                sentencia.Connection = con;

                var result = sentencia.ExecuteNonQuery();
                var mensaje = "";
                if (result > 0)
                {
                    mensaje = "REGISTRO ACTUALIZADO";
                }
                else
                {
                    mensaje = "ERROR";
                }
                ViewBag.mensaje = mensaje;

                return View("/Views/Check_out/Check_out.cshtml");

            }
        }

        public ActionResult mostrar_rut(string rutx)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = bdd_hotel_system; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select rut, nombre, apellidos, mail, ciudad, pais, tiporeserva, diareserva, tipohabitacion from reservaciones";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "";
            while (dr.Read())
            {
                if (dr["rut"].ToString() == rutx)
                {
                    ViewBag.rut = dr["rut"].ToString();
                    ViewBag.nombre = dr["nombre"].ToString();
                    ViewBag.apellidos = dr["apellidos"].ToString();
                    ViewBag.mail = dr["mail"].ToString();
                    ViewBag.ciudad = dr["ciudad"].ToString();
                    ViewBag.tiporeserva = dr["tiporeserva"].ToString();
                    ViewBag.diareserva = dr["diareserva"].ToString();
                    ViewBag.tipohabitacion = dr["tipohabitacion"].ToString();

                }
            }

            return View("/Views/Reservaciones/Reservaciones.cshtml");
        }

        //METODO PARA CUENTA DE USUARIO 
        public ActionResult Checkin_Checkout(string rut, string nombre)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_hotel_system;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select rut_admin, nombre_admin, privilegiado from admin";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "";
            var privilegiado = "";
            while (dr.Read())
            {
                if (dr["rut_admin"].ToString() == rut)
                {
                    if (dr["nombre_admin"].ToString() == nombre)
                    {
                        mensaje = "Acceso_Ok";
                        privilegiado = dr["privilegiado"].ToString();
                    }
                }
            }
            if (mensaje == "Acceso_Ok")
            {
                ViewBag.privilegiado = privilegiado;
                return View("/Views/Checkin_Checkout/Checkin_Checkout.cshtml");

            }
            else
            {
                ViewBag.mensaje = "Rut o Nombre erroneos";
                return View("/Views/Usuarios/Usuarios.cshtml");
            }
        }



        public ActionResult Ingreso_Reservaciones(string privilegio)
        {
            var mensaje = "";
            if (privilegio == "1")
            {
                return View("/Views/Reservaciones/Reservaciones.cshtml");
            }
            else
            {
                ViewBag.mensaje = "No tiene los Privilegios";
                return View("/Views/Checkin_Checkout/Checkin_Checkout.cshtml");
            }
        }

        public ActionResult crearadmin(string privilegio)
        {
            var mensaje = "";
            if (privilegio == "1")
            {
                return View("/Views/crearadmin/crearadmin.cshtml");
            }
            else
            {
                ViewBag.mensaje = "No tiene los Privilegios";
                return View("/Views/Checkin_Checkout/Checkin_Checkout.cshtml");
            }
                        
        }


        /* public ActionResult Checkin_Checkout(string rut, string nombre)
         {
             SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_hotel_system;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
             var sentencia = new SqlCommand();
             SqlDataReader dr;
             sentencia.Connection = con;
             sentencia.CommandText = "select rut_admin, nombre_admin from admin, privilegiado from admin ";
             sentencia.CommandType = System.Data.CommandType.Text;
             con.Open();
             dr = sentencia.ExecuteReader();
             var mensaje = "";
             var privilegiado = "";
             while (dr.Read())
             {
                 if (dr["rut_admin"].ToString() == rut)
                 {
                     if (dr["nombre_admin"].ToString() == nombre)
                     {
                         mensaje = "Acceso_Ok";
                        privilegiado = dr["privilegiado"].ToString();
                     }
                 }
             }
             if (mensaje == "Acceso_Ok")
             {
                ViewBag.privilegiado = privilegiado;
                 return View("/Views/Checkin_Checkout/Checkin_Checkout.cshtml");
             }
             else
             {
                 ViewBag.mensaje = "Rut o Nombre erroneos o usuario no ingresado";
                 return View("/Views/Usuarios/Usuarios.cshtml");
             }
         }*/

        public ActionResult deletereserva(string rutt)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_hotel_system;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            var sentencia = new SqlCommand();
            sentencia.CommandType = System.Data.CommandType.Text;
            sentencia.CommandText = "delete from reservaciones where rut = @prut";
            sentencia.Parameters.Add(new SqlParameter("prut", rutt));

            sentencia.Connection = con;

            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result > 0)
            {
                mensaje = "REGISTRO DE RESERVA ELIMINADO CON EXITO";
            }
            else
            {
                mensaje = "ERROR";
            }
            ViewBag.mensaje = mensaje;

            return View("/Views/Check_in/Check_in.cshtml");

        }
 

        public ActionResult save_admin(string rutadmin, string nombreadmin, string privilegiado)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_hotel_system;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            var sentencia = new SqlCommand();
            sentencia.CommandType = System.Data.CommandType.Text;
            if (nombreadmin == "" || rutadmin == "")
            {
                
                ViewBag.Error = "Error - Faltan Datos";
                return View("/Views/crearadmin/crearadmin.cshtml");
               
            }
            else
            {
                sentencia.CommandText = "insert into admin (rut_admin, nombre_admin, privilegiado) values (@prut_admin, @pnombre_admin, @pprivilegiado)";
                sentencia.Parameters.Add(new SqlParameter("prut_admin", rutadmin));
                sentencia.Parameters.Add(new SqlParameter("pnombre_admin", nombreadmin));
                sentencia.Parameters.Add(new SqlParameter("pprivilegiado", privilegiado));
               

                sentencia.Connection = con;
                
                var result = sentencia.ExecuteNonQuery();
                var mensaje = "";
                if (result > 0)
                {
                    mensaje = "REGISTRO DE CUENTA GUARDADO CON EXITO";
                }
                else
                {
                    mensaje = "ERROR";
                }
                ViewBag.mensaje = mensaje;

                return View("/Views/Checkin_Checkout/Checkin_Checkout.cshtml");
            }
        }
    }
}
         