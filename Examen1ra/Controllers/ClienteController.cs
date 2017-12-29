using Examen1ra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen1ra.Controllers
{
    public class ClienteController : Controller
    {
        Examen1ra.Models.TiendaEntities cnx;

        public ClienteController()
        {

            cnx = new Models.TiendaEntities();
        }
        public ActionResult Listado()
        {

            return View(cnx.Cliente.ToList());
        }

        public ActionResult Mantenedor()
        {

            return View();
        }
        public ActionResult Guardar(int rut, string nombre, string apellido, string direccion, string tipocliente)
        {
            Cliente nuevo = new Cliente()
            {
                rut = rut,
                nombre = nombre,
                apellido = apellido,
                direccion = direccion,
                tipocliente = tipocliente
            };
            cnx.Cliente.Add(nuevo);
            cnx.SaveChanges();

            return View("Listado", cnx.Cliente.ToList());
        }

        public ActionResult Ficha(int rut)
        {

            return View(cnx.Cliente.Where(x => x.rut == rut).First());
        }
        
    }
}